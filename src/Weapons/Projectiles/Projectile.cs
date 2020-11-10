using Godot;

namespace TopDownDemo.Weapons.Projectiles
{
    public abstract class Projectile : Node2D
    {
        [Export] public int Damage = 1;
        [Export] public float Speed = 10;
        [Export] public Vector2 Direction = Vector2.Zero;

        public Node2D SourceWeaponDisplay;

        public override void _PhysicsProcess(float delta)
        {
            GlobalPosition += Direction.Normalized() * Speed * delta;
        }
    }
}
