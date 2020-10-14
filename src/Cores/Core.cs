using Godot;
using TopDownDemo.Cores.MovementCore;

namespace TopDownDemo.Cores
{
    public class Core : Node2D
    {
        public Movement Movement;

        public override void _Ready()
        {
            Movement = GetNodeOrNull<Movement>("Movement");
        }
    }
}
