using Godot;

namespace TopDownDemo.Mechanics.Attacks.IndividualCoolDownAttack
{
    /**
     * Requirement: Mechanic.IndividualCoolDownAttack.Attack
     */
    public class IndividualCoolDownAttack : Node2D
    {
        [Export] public float CoolDown = 1f;
        [Export] public string Trigger;
        public Attack Attack;
        public float CountDown;

        public override void _Ready()
        {
            CacheAttack();
        }

        public override void _PhysicsProcess(float delta)
        {
            CountDown -= delta;
            HandleAttack();
        }

        private void CacheAttack()
        {
            Attack = GetChild<Attack>(0);
        }

        private void HandleAttack()
        {
            if (!Input.IsActionPressed(Trigger) || CountDown > 0) return;
            Attack.Execute();
            CountDown = CoolDown;
        }
    }
}
