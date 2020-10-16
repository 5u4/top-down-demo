using Godot;

namespace TopDownDemo.Mechanics.Reload
{
    /**
     * Requirement: Mechanic.Magazine
     */
    public class Reload : Node2D
    {
        [Export] public string ReloadAnimation = "Reload";
        [Export] public string FallbackAnimation = "Reset";

        public Mechanic Mechanic;

        public override void _Ready()
        {
            Mechanic = GetParent<Mechanic>();

            var animationPlayer = Mechanic.WeaponGetter.AnimationPlayerGetter;
            animationPlayer.Connect("animation_finished", this, nameof(OnAnimationFinished));
        }

        public override void _PhysicsProcess(float delta)
        {
            if (!Input.IsActionPressed("reload")) return;
            StartReloading();
        }

        public void StartReloading()
        {
            var anim = Mechanic.Magazine.Amount < Mechanic.Magazine.Volume ? ReloadAnimation : FallbackAnimation;
            Mechanic.Weapon.AnimationPlayer.Play(anim);
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
