using Godot;
using TopDownDemo.Mechanics;
using TopDownDemo.Mechanics.Attacks;

namespace TopDownDemo.Weapons.Ranged.Pistol
{
    public class PrimaryAttack : Attack
    {
        public Mechanic Mechanic;

        public override void _Ready()
        {
            Mechanic = GetNode<Mechanic>("../..");
        }

        public override void Execute()
        {
            Mechanic.Weapon.AnimationPlayer.Play("WeaponPrimary");
        }
    }
}
