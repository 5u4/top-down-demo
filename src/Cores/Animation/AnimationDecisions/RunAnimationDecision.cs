using Godot;

namespace TopDownDemo.Cores.Animation.AnimationDecisions
{
    public class RunAnimationDecision : AnimationDecision
    {
        public Cores.Animation.Animation Animation;
        public const float MoveSpeedThreshold = 4f;

        public override void _Ready()
        {
            Animation = GetNode<Cores.Animation.Animation>("..");
        }

        public override string Decide()
        {
            return Animation.Creature.Core.Movement.Velocity.DistanceTo(Vector2.Zero) > MoveSpeedThreshold ? "Run" : null;
        }
    }
}
