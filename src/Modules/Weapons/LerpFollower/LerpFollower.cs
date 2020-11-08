using Godot;

namespace TopDownDemo.Modules.Weapons.LerpFollower
{
    public class LerpFollower : Module
    {
        [Export] public NodePath TargetPath = "../../../../KinematicBody2D";
        [Export] public NodePath DisplayPath = "../../Display";
        [Export] public Vector2 Offset = Vector2.Zero;
        [Export] public float Weight = 0.045f;

        public KinematicBody2D Target;
        public Node2D Display;

        public override void _Ready()
        {
            Target = GetNode<KinematicBody2D>(TargetPath);
            Display = GetNode<Node2D>(DisplayPath);
        }

        public override void _PhysicsProcess(float delta)
        {
            HandleMovement();
        }

        private void HandleMovement()
        {
            var position = Vector2.Zero;
            position.x = Mathf.Lerp(Display.GlobalPosition.x, Target.GlobalPosition.x + Offset.x, Weight);
            position.y = Mathf.Lerp(Display.GlobalPosition.y, Target.GlobalPosition.y + Offset.y, Weight);
            Display.GlobalPosition = position;
        }
    }
}
