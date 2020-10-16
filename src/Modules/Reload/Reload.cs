using Godot;
using TopDownDemo.Cores.ActionLock;
using TopDownDemo.Mechanics.Magazine;

namespace TopDownDemo.Modules.Reload
{
    public class Reload : Node2D
    {
        [Export] public string ReloadAnimation = "Reload";
        [Export] public string FallbackAnimation = "Reset";
        [Export] public NodePath MagazinePath;
        [Export] public NodePath AnimationPlayerPath;

        public Magazine Magazine;
        public AnimationPlayer AnimationPlayer;
        public ActionLock ActionLock;

        public override void _Ready()
        {
            Magazine = GetNode<Magazine>(MagazinePath);
            AnimationPlayer = GetNode<AnimationPlayer>(AnimationPlayerPath);
            ActionLock = GetNode<ActionLock>("ActionLock");

            AnimationPlayer.Connect("animation_finished", this, nameof(OnAnimationFinished));
        }

        public override void _PhysicsProcess(float delta)
        {
            if (!Input.IsActionPressed("reload") || IsReloading()) return;
            StartReloading();
        }

        public bool IsReloading()
        {
            return AnimationPlayer.CurrentAnimation == ReloadAnimation;
        }

        public async void StartReloading()
        {
            if (Magazine.Amount >= Magazine.Volume)
            {
                AnimationPlayer.Play(FallbackAnimation);
                ActionLock.Unlock();
                return;
            }
            ActionLock.Lock();
            AnimationPlayer.Play(ReloadAnimation);
            await ToSignal(AnimationPlayer, "animation_finished");
        }

        public void LoadOne()
        {
            Magazine.Gain();
        }

        private void OnAnimationFinished(string anim)
        {
            if (anim != ReloadAnimation) return;
            StartReloading();
        }
    }
}
