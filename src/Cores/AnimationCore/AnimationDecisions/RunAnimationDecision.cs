using Godot;
using TopDownDemo.Creatures;

namespace TopDownDemo.Cores.AnimationCore.AnimationDecisions
{
    public class RunAnimationDecision : AnimationDecision
    {
        public Animation Animation;
        public const float MoveSpeedThreshold = 4f;

        public override void _Ready()
        {
            Animation = GetNode<Animation>("..");
        }

        public override string Decide()
        {
            return Animation.Creature.Core.Movement.Velocity.DistanceTo(Vector2.Zero) > MoveSpeedThreshold ? "Run" : null;
        }
    }
}
