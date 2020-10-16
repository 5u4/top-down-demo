using Godot;

namespace TopDownDemo.Weapons
{
    public class Weapon : Node2D
    {
        public Node2D GlobalHandle;
        public Node2D LocalHandle;
        public AnimationPlayer AnimationPlayer;
        public AnimationPlayer AnimationPlayerGetter => GetNode<AnimationPlayer>("AnimationPlayer");

        public override void _Ready()
        {
            GlobalHandle = GetNode<Node2D>("GlobalHandle");
            LocalHandle = GlobalHandle.GetNode<Node2D>("LocalHandle");
            AnimationPlayer = AnimationPlayerGetter;
        }
    }
}
