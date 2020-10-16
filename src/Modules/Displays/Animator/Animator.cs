using System.Linq;
using Godot;
using Godot.Collections;
using TopDownDemo.Modules.Displays.Animator.AnimationDecisions;

namespace TopDownDemo.Modules.Displays.Animator
{
    public class Animator : Module
    {
        [Export] public NodePath AnimatedSpritePath;
        [Export] public NodePath AnimationPlayerPath;

        public AnimatedSprite AnimatedSprite;
        public AnimationPlayer AnimationPlayer;

        public Array<AnimationDecision> Decisions = new Array<AnimationDecision>();

        public override void _Ready()
        {
            AnimatedSprite = GetNode<AnimatedSprite>(AnimatedSpritePath);
            AnimationPlayer = GetNode<AnimationPlayer>(AnimationPlayerPath);

            AnimatedSprite.Play();

            CacheDecisions();
        }

        public override void _PhysicsProcess(float delta)
        {
            PlayAnimation();
        }

        private void PlayAnimation()
        {
            var anim = AnimationPlayer.CurrentAnimation;
            var nextAnim = SelectAnimation();
            if (anim == nextAnim) return;
            AnimationPlayer.Play(nextAnim);
        }

        private string SelectAnimation()
        {
            return Decisions.Select(decision => decision.Decide()).FirstOrDefault(anim => anim != null);
        }

        private void CacheDecisions()
        {
            foreach (var child in GetChildren())
            {
                if (child is AnimationDecision decision) Decisions.Add(decision);
            }
        }
    }
}
