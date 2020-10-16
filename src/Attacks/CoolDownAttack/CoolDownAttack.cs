using Godot;
using TopDownDemo.Cores.ActionLock;

namespace TopDownDemo.Attacks.CoolDownAttack
{
    public class CoolDownAttack : Node2D
    {
        [Export] public NodePath AttackPath;
        [Export] public NodePath ActionLockPath;
        [Export] public float CoolDown = 1;
        [Export] public string Trigger;

        public Attack Attack;
        public ActionLock ActionLock;

        public override void _Ready()
        {
            Attack = GetNode<Attack>(AttackPath);
            ActionLock = GetNode<ActionLock>(ActionLockPath);
        }

        public override void _PhysicsProcess(float delta)
        {
            if (!Input.IsActionPressed(Trigger) || ActionLock.IsLocked) return;
            ActionLock.Lock(CoolDown);
            Attack.Execute();
        }
    }
}
