using Godot;

namespace TopDownDemo.Mechanics.Magazine
{
    public class Magazine : Node2D
    {
        [Export] public int Volume;

        public int Amount { get; private set; }

        public override void _Ready()
        {
            Amount = Volume;
        }

        public void Reduce(int amount = 1)
        {
            Amount = Mathf.Max(0, Amount - amount);
        }

        public void Gain(int amount = 1)
        {
            Amount = Mathf.Min(Volume, Amount + amount);
        }
    }
}
