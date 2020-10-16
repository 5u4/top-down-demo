using Godot;

namespace TopDownDemo.Modules.LookAtCursor
{
    public class LookAtCursor : Module
    {
        [Export] public NodePath HandlePath;

        public Node2D Handle;

        public override void _Ready()
        {
            Handle = GetNode<Node2D>(HandlePath);
        }

        public override void _PhysicsProcess(float delta)
        {
            HandleRotation();
        }

        private void HandleRotation()
        {
            var mouse = GetGlobalMousePosition();
            Handle.LookAt(mouse);

            // TODO: Should be handled by two side flipper
            var angle = Mathf.Rad2Deg((mouse - Handle.GlobalPosition).Angle());
            var shouldFlip = angle <= -90 || angle >= 90;

            var scale = Handle.Scale;
            scale.y = Mathf.Abs(scale.y) * (shouldFlip ? -1 : 1);

            Handle.Scale = scale;
        }
    }
}
