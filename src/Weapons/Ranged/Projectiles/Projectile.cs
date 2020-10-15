using Godot;

namespace TopDownDemo.Weapons.Ranged.Projectiles
{
    public abstract class Projectile : Area2D
    {
        [Export] public float Speed;

        public Vector2 Direction = Vector2.Zero;

        public AnimationPlayer AnimationPlayer;

        public override void _Ready()
        {
            AnimationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        }
    }
}
