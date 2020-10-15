using Godot;

namespace TopDownDemo.Weapons.Ranged.Projectiles.Modules.LinearTraveller
{
    public class LinearTraveller : Node2D
    {
        public Projectile Projectile;

        public override void _Ready()
        {
            Projectile = GetNode<Projectile>("../..");
        }

        public override void _PhysicsProcess(float delta)
        {
            Projectile.GlobalPosition += Projectile.Direction * Projectile.Speed * delta;
        }
    }
}
