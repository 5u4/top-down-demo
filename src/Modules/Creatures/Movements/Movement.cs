using Godot;

namespace TopDownDemo.Modules.Creatures.Movements
{
    public class Movement : Module
    {
        [Export] public NodePath BodyPath = "../../KinematicBody2D";
        [Export] public float MoveSpeed = 200f;
        [Export] public float Acceleration = 0.5f;
        [Export] public float Friction = 0.25f;

        public Vector2 Velocity;
        public KinematicBody2D Body;

        public override void _Ready()
        {
            Body = GetNode<KinematicBody2D>(BodyPath);
        }

        public override void _PhysicsProcess(float delta)
        {
            Velocity = Body.MoveAndSlide(Velocity);
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
