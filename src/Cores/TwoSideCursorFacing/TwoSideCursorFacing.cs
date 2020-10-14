using Godot;
using TopDownDemo.Creatures;

namespace TopDownDemo.Cores.TwoSideCursorFacing
{
    public class TwoSideCursorFacing : Node2D
    {
        public Creature Creature;

        public override void _Ready()
        {
            Creature = GetNode<Creature>("../..");
        }

        public override void _PhysicsProcess(float delta)
        {
            HandleFlip();
        }

        private void HandleFlip()
        {
            var angle = Mathf.Rad2Deg((GetGlobalMousePosition() - Creature.GlobalPosition).Angle());
            var shouldFlip = angle <= -90 || angle >= 90;
            var scale = Creature.Scale;
            scale.x = shouldFlip ? -1 * Mathf.Abs(scale.x) : Mathf.Abs(scale.x); // TODO: Flip display handle
            Creature.AnimatedSprite.Scale = scale;
            Creature.AnimatedSprite.Play(null, shouldFlip);
        }
    }
}
