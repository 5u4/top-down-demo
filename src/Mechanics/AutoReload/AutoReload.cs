using System.Linq;
using Godot;

namespace TopDownDemo.Mechanics.AutoReload
{
    /**
     * Requirement: Mechanic.Reload, Mechanic.Magazine
     */
    public class AutoReload : Node2D
    {
        [Export] public string[] Triggers = {"weapon_primary", "weapon_secondary"};

        public Mechanic Mechanic;

        public override void _Ready()
        {
            Mechanic = GetParent<Mechanic>();
        }

        public override void _PhysicsProcess(float delta)
        {
            if (!Triggers.Any(Input.IsActionPressed)
                || Mechanic.Magazine.Amount > 0
                || Mechanic.Weapon.AnimationPlayer.IsPlaying()) return;
            Mechanic.Reload.StartReloading();
        }
    }
}
