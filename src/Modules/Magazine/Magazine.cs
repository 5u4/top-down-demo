using Godot;

namespace TopDownDemo.Modules.Magazine
{
    public class Magazine : Module
    {
        [Export] public int Volume;

        public int Amount { get; private set; }

        public override void _Ready()
        {
            Amount = Volume;
        }

        public void Increase(int amount = 1)
        {
            Amount = Mathf.Clamp(Amount - amount, 0, Volume);
        }

        public void Decrease(int amount = 1)
        {
            Amount = Mathf.Clamp(Amount + amount, 0, Volume);
        }
    }
}
