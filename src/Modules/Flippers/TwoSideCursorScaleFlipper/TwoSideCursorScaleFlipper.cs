using Godot;

namespace TopDownDemo.Modules.Flippers.TwoSideCursorScaleFlipper
{
    public class TwoSideCursorScaleFlipper : Flipper
    {
        [Export] public NodePath ScaleReferencePath;

        public Node2D ScaleReference;

        public override void _Ready()
        {
            base._Ready();

            ScaleReference = GetNode<Node2D>(ScaleReferencePath);
        }

        public override void HandleFlip()
        {
            var scale = ScaleReference.Scale;
            scale.y = Mathf.Abs(scale.y) * (ShouldFlip() ? -1 : 1);
            ScaleReference.Scale = scale;
        }
    }
}
