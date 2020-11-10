using Godot;
using TopDownDemo.Weapons.Projectiles;

namespace TopDownDemo.Modifiers
{
    public abstract class Attachment : Node2D
    {
        public Projectile Projectile;

        public override void _Ready()
        {
            Projectile = GetParent<Projectile>();
        }
    }
}