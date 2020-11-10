using Godot;

namespace TopDownDemo.Modules.Triggers.Conditions
{
    public abstract class Condition : Node2D
    {
        public abstract bool Ok();
        public virtual void Trigger() {}
    }
}
