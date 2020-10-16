using Godot;

namespace TopDownDemo.Modules.Displays.Animator.AnimationDecisions
{
    public abstract class AnimationDecision : Node2D
    {
        public abstract string Decide();
    }
}
