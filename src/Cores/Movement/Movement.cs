using Godot;
using TopDownDemo.Creatures;

namespace TopDownDemo.Cores.Movement
{
    public class Movement : Node2D
    {
        public Vector2 Velocity;
        public Creature Creature;

        [Export] public float MoveSpeed = 50f;
        [Export] public float Acceleration = 0.5f;
        [Export] public float Friction = 0.25f;

        public override void _Ready()
        {
            Creature = GetNode<Creature>("../..");
        }

        public override void _PhysicsProcess(float delta)
        {
            Velocity = Creature.MoveAndSlide(Velocity);
        }

        public void MoveTowards(Vector2 direction)
        {
            Velocity = ComputeVelocityVector(direction, MoveSpeed);
        }

        private Vector2 ComputeVelocityVector(Vector2 direction, float speed)
        {
            direction = direction.Normalized();
            direction.x = ComputeAxisMovement(direction.x, Velocity.x, direction.x * speed, Acceleration, Friction);
            direction.y = ComputeAxisMovement(direction.y, Velocity.y, direction.y * speed, Acceleration, Friction);
            return direction;
        }

        private float ComputeAxisMovement(float movement, float axis, float maxSpeed, float acceleration, float friction)
        {
            return Mathf.Abs(movement) > 0
                ? Mathf.Lerp(axis, maxSpeed, acceleration)
                : Mathf.Lerp(axis, 0, friction);
        }
    }
}
