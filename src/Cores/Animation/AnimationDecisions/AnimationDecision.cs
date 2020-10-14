using Godot;

namespace TopDownDemo.Cores.Animation.AnimationDecisions
{
    public abstract class AnimationDecision : Node2D
    {
        public abstract string Decide();
    }
}
