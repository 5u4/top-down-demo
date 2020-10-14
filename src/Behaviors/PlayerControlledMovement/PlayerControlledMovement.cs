using Godot;
using TopDownDemo.Creatures;

namespace TopDownDemo.Behaviors.PlayerControlledMovement
{
    public class PlayerControlledMovement : Node2D
    {
        public Creature Creature;
        public Vector2 Direction;

        public override void _Ready()
        {
            Creature = GetNode<Creature>("../..");
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
            Creature.Core.Movement.MoveTowards(Direction);
        }
    }
}
