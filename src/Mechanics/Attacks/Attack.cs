using Godot;

namespace TopDownDemo.Mechanics.Attacks
{
    public abstract class Attack : Node2D
    {
        public abstract void Execute();
    }
}
