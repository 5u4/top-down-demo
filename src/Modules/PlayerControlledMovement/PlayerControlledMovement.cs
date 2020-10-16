using Godot;
using TopDownDemo.Cores.Movement;

namespace TopDownDemo.Modules.PlayerControlledMovement
{
    public class PlayerControlledMovement : Module
    {
        [Export] public NodePath MovementPath;

        public Movement Movement;
        public Vector2 Direction;

        public override void _Ready()
        {
            Movement = GetNode<Movement>(MovementPath);
        }

        public override void _PhysicsProcess(float delta)
        {
            HandleMovement();
        }

        private void HandleMovement()
        {
            Direction = Vector2.Zero;
            if (Input.IsActionPressed("move_left")) Direction += Vector2.Left;
            if (Input.IsActionPressed("move_right")) Direction += Vector2.Right;
            if (Input.IsActionPressed("move_up")) Direction += Vector2.Up;
            if (Input.IsActionPressed("move_down")) Direction += Vector2.Down;
            Movement.MoveTowards(Direction);
        }
    }
}
