using Godot;

namespace TopDownDemo.Modules.Displays.LookAtCursor
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
        }
    }
}
