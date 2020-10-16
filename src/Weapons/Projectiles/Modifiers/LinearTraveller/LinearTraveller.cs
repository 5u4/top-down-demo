using Godot;

namespace TopDownDemo.Weapons.Projectiles.Modifiers.LinearTraveller
{
    public class LinearTraveller : Node2D
    {
        [Export] public NodePath ProjectilePath;

        public Projectile Projectile;

        public override void _Ready()
        {
            Projectile = GetNode<Projectile>(ProjectilePath);
        }

        public override void _PhysicsProcess(float delta)
        {
            Projectile.GlobalPosition += Projectile.Direction * Projectile.Speed * delta;
        }
    }
}
