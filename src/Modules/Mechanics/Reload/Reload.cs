using Godot;
using TopDownDemo.Cores.ActionLock;

namespace TopDownDemo.Modules.Mechanics.Reload
{
    public class Reload : Module
    {
        [Export] public string ReloadAnimation = "Reload";
        [Export] public string FallbackAnimation = "Reset";
        [Export] public NodePath MagazinePath;
        [Export] public NodePath AnimationPlayerPath;

        public Magazine.Magazine Magazine;
        public AnimationPlayer AnimationPlayer;
        public ActionLock ActionLock;

        public override void _Ready()
        {
            Magazine = GetNode<Magazine.Magazine>(MagazinePath);
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
            Magazine.Increase();
        }

        public void LoadAll()
        {
            Magazine.LoadAll();
        }

        private void OnAnimationFinished(string anim)
        {
            if (anim != ReloadAnimation) return;
            StartReloading();
        }
    }
}
