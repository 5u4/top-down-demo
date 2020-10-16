using Godot;
using TopDownDemo.Cores.ActionLock;

namespace TopDownDemo.Mechanics.Reload
{
    /**
     * Requirement: Mechanic.Magazine, Mechanic.ActionLock
     */
    public class Reload : Node2D
    {
        [Export] public string ReloadAnimation = "Reload";
        [Export] public string FallbackAnimation = "Reset";

        public Mechanic Mechanic;
        public AnimationPlayer AnimationPlayer;
        public ActionLock ActionLock;

        public override void _Ready()
        {
            Mechanic = GetParent<Mechanic>();
            ActionLock = GetNode<ActionLock>("ActionLock");

            AnimationPlayer = Mechanic.WeaponGetter.AnimationPlayerGetter;
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
            if (Mechanic.Magazine.Amount >= Mechanic.Magazine.Volume)
            {
                Mechanic.Weapon.AnimationPlayer.Play(FallbackAnimation);
                ActionLock.Unlock();
                return;
            }
            ActionLock.Lock();
            Mechanic.Weapon.AnimationPlayer.Play(ReloadAnimation);
            await ToSignal(Mechanic.Weapon.AnimationPlayer, "animation_finished");
        }

        public void LoadOne()
        {
            Mechanic.Magazine.Gain();
        }

        private void OnAnimationFinished(string anim)
        {
            if (anim != ReloadAnimation) return;
            StartReloading();
        }
    }
}
