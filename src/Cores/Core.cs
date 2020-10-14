using Godot;

namespace TopDownDemo.Cores
{
    public class Core : Node2D
    {
        public Movement.Movement Movement;

        public override void _Ready()
        {
            Movement = GetNodeOrNull<Movement.Movement>("Movement");
        }
    }
}
