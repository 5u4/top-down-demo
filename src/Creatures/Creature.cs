using Godot;
using TopDownDemo.Behaviors;
using TopDownDemo.Cores;

namespace TopDownDemo.Creatures
{
    public abstract class Creature : KinematicBody2D
    {
        public CollisionShape2D Collision;
        public AnimatedSprite AnimatedSprite;
        public AnimationPlayer AnimationPlayer;

        public Core Core;
        public Behavior Behavior;
        public Node2D Plugin;

        public override void _Ready()
        {
            Collision = GetNode<CollisionShape2D>("CollisionShape2D");
            AnimatedSprite = GetNode<AnimatedSprite>("AnimatedSprite");
            AnimationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");

            Core = GetNode<Core>("Core");
            Behavior = GetNode<Behavior>("Behavior");
            Plugin = GetNode<Node2D>("Plugin");
        }
    }
}
