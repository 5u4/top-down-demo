using Godot;

namespace TopDownDemo.Weapons
{
    public class Weapon : Node2D
    {
        public Node2D Display;
        public AnimationPlayer AnimationPlayer;

        public override void _Ready()
        {
            Display = GetNode<Node2D>("Display");
            AnimationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
        }
    }
}
