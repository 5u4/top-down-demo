using Godot;

namespace TopDownDemo.Modules.Displays.Flippers
{
    public abstract class Flipper : Module
    {
        [Export] public NodePath ReferencePath;

        public Node2D Reference;

        public override void _Ready()
        {
            Reference = GetNode<Node2D>(ReferencePath);
        }

        public override void _PhysicsProcess(float delta)
        {
            HandleFlip();
        }

        public virtual bool ShouldFlip()
        {
            var angle = Mathf.Rad2Deg((GetGlobalMousePosition() - Reference.GlobalPosition).Angle());
            return angle <= -90 || angle >= 90;
        }

        public abstract void HandleFlip();
    }
}
