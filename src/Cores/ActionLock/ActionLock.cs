using Godot;

namespace TopDownDemo.Cores.ActionLock
{
    public class ActionLock : Timer
    {
        public bool IsLocked { get; private set; }

        public override void _Ready()
        {
            Connect("timeout", this, nameof(OnTimeout));
        }

        public void Lock()
        {
            IsLocked = true;
        }

        public void Lock(float duration)
        {
            Start(duration);
            IsLocked = true;
        }

        public void Unlock()
        {
            IsLocked = false;
            Stop();
        }

        public void OnTimeout()
        {
            IsLocked = false;
            Stop();
        }
    }
}
