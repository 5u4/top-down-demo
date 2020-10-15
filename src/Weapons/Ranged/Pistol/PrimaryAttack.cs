using Godot;
using TopDownDemo.Mechanics;
using TopDownDemo.Mechanics.Attacks;

namespace TopDownDemo.Weapons.Ranged.Pistol
{
    /**
     * Requirement: Mechanic.Magazine
     */
    public class PrimaryAttack : Attack
    {
        public Mechanic Mechanic;

        public override void _Ready()
        {
            Mechanic = GetNode<Mechanic>("../..");
        }

        public override void Execute()
        {
            if (Mechanic.Magazine.Amount <= 0) return; // TODO: Handle empty magazine
            Mechanic.Magazine.Reduce();
            Mechanic.Weapon.AnimationPlayer.Play("WeaponPrimary");
        }
    }
}
