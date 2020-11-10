using Godot;

namespace TopDownDemo.Modifiers.AttachedModifiers.SelfDestroyModifier
{
    public class SelfDestroyAttachment : Attachment
    {
        [Export] public float LiveTime = 1;

        public Timer Timer;

        public override void _Ready()
        {
            base._Ready();

            Timer = GetNode<Timer>("Timer");
            Timer.Connect("timeout", this, nameof(OnTimeout));
            Timer.Start(LiveTime);
        }

        private void OnTimeout()
        {
            Projectile.Destroy();
        }
    }
}
