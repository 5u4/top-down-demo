using Godot;

namespace TopDownDemo.Modules.Flippers.TwoSideCursorAnimatedSpriteFlipper
{
    public class TwoSideCursorAnimatedSpriteFlipper : Flipper
    {
        [Export] public NodePath AnimatedSpritePath;

        public AnimatedSprite AnimatedSprite;

        public override void _Ready()
        {
            base._Ready();

            AnimatedSprite = GetNode<AnimatedSprite>(AnimatedSpritePath);
        }

        public override void HandleFlip()
        {
            var shouldFlip = ShouldFlip();
            AnimatedSprite.FlipH = shouldFlip;
            AnimatedSprite.Play(null, shouldFlip);
        }
    }
}
