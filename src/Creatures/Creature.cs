using Godot;
using TopDownDemo.Cores;

namespace TopDownDemo.Creatures
{
    public abstract class Creature : Node2D
    {
        public KinematicBody2D Body;
        public CollisionShape2D Collision;
        public AnimatedSprite AnimatedSprite;
        public AnimationPlayer AnimationPlayer;

        public Core Core;
        public Node2D Plugin;

        public override void _Ready()
        {
            Body = GetNode<KinematicBody2D>("Body");
            Collision = Body.GetNode<CollisionShape2D>("CollisionShape2D");
            AnimatedSprite = Body.GetNode<AnimatedSprite>("AnimatedSprite");
            AnimationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");

            Core = GetNode<Core>("Core");
            Plugin = Body.GetNode<Node2D>("Plugin");
        }
    }
}
