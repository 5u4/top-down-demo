using Godot;

namespace TopDownDemo.Modules.Triggers.Conditions.CoolDownCondition
{
    public class CoolDownCondition : Condition
    {
        [Export] public float Interval = 1;

        public Timer Timer;
        public bool InCoolDown;

        public override void _Ready()
        {
            Timer = GetNode<Timer>("Timer");

            Timer.Connect("timeout", this, nameof(OnTimeout));
        }

        public override bool Ok()
        {
            return !InCoolDown;
        }

        public override void Trigger()
        {
            InCoolDown = true;
            Timer.Start(Interval);
        }

        private void OnTimeout()
        {
            InCoolDown = false;
        }
    }
}
