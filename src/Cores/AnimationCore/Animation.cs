using System.Linq;
using Godot;
using Godot.Collections;
using TopDownDemo.Cores.AnimationCore.AnimationDecisions;
using TopDownDemo.Creatures;

namespace TopDownDemo.Cores.AnimationCore
{
    public class Animation : Node2D
    {
        public Creature Creature;
        public AnimatedSprite AnimatedSprite;
        public AnimationPlayer AnimationPlayer;

        public Array<AnimationDecision> Decisions = new Array<AnimationDecision>();

        public override void _Ready()
        {
            Creature = GetNode<Creature>("../..");

            AnimatedSprite = Creature.GetNode<AnimatedSprite>("AnimatedSprite");
            AnimationPlayer = Creature.GetNode<AnimationPlayer>("AnimationPlayer");

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
