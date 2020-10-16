using Godot;
using TopDownDemo.Cores.Movement;

namespace TopDownDemo.Modules.Displays.Animator.AnimationDecisions
{
    public class RunAnimationDecision : AnimationDecision
    {
        [Export] public NodePath MovementPath;

        public Movement Movement;
        public const float MoveSpeedThreshold = 4f;

        public override void _Ready()
        {
            Movement = GetNode<Movement>(MovementPath);
        }

        public override string Decide()
        {
            return Movement.Velocity.DistanceTo(Vector2.Zero) > MoveSpeedThreshold ? "Run" : null;
        }
    }
}
