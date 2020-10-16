using Godot;
using TopDownDemo.Weapons;

namespace TopDownDemo.Mechanics
{
    public class Mechanic : Node2D
    {
        public Weapon WeaponGetter => GetParent<Weapon>();

        public Weapon Weapon;
        public Magazine.Magazine Magazine;

        public override void _Ready()
        {
            Weapon = WeaponGetter;
            Magazine = GetNodeOrNull<Magazine.Magazine>("Magazine");
        }
    }
}
