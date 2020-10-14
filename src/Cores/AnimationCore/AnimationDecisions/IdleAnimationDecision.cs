using System;

namespace TopDownDemo.Cores.AnimationCore.AnimationDecisions
{
    public class IdleAnimationDecision : AnimationDecision
    {
        public override string Decide()
        {
            return "Idle";
        }
    }
}
