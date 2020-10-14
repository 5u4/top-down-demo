using Godot;
using TopDownDemo.Weapons;

namespace TopDownDemo.Mechanics
{
    public class Mechanic : Node2D
    {
        public Weapon Weapon;

        public override void _Ready()
        {
            Weapon = GetParent<Weapon>();
        }
    }
}
