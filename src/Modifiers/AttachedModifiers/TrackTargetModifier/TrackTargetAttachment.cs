using Godot;
using TopDownDemo.Creatures;

namespace TopDownDemo.Modifiers.AttachedModifiers.TrackTargetModifier
{
    public class TrackTargetAttachment : Attachment
    {
        [Export] public float Sight = 1;
        [Export] public float SteeringScale = 0.001f;
        [Export] public float SteeringAcceleration;
        [Export] public float TargetFindingInterval = 0.1f;

        public Area2D Area;
        public CollisionShape2D Collision;
        public Timer Timer;
        public Creature Target;
        public bool ReadyForTargetFinding = true;

        public override void _Ready()
        {
            base._Ready();

            Area = GetNode<Area2D>("Area2D");
            Collision = GetNode<CollisionShape2D>("Area2D/CollisionShape2D");
            Timer = GetNode<Timer>("Timer");

            Collision.Shape = new CircleShape2D {Radius = Sight};
            Timer.Connect("timeout", this, nameof(OnTimeout));
        }


        public override void _PhysicsProcess(float delta)
        {
            if (Target == null) FindTarget();
            else TrackTarget(delta);
        }

        private void FindTarget()
        {
            if (!ReadyForTargetFinding) return;
            Timer.Start(TargetFindingInterval);
            ReadyForTargetFinding = false;

            foreach (var node in Area.GetOverlappingBodies())
            {
                if (!(node is KinematicBody2D body) || !(body.GetParent() is Creature creature)) continue;
                if (creature.Faction != Faction.None && creature.Faction == Projectile.Faction) continue;
                Target = creature;
                return;
            }
        }

        private void TrackTarget(float delta)
        {
            var desiredVector = Projectile.GlobalPosition.DirectionTo(Target.GlobalPosition) * Projectile.Speed;
            var steeringVector = (desiredVector - Projectile.Direction) * SteeringScale;
            SteeringScale += SteeringScale * SteeringAcceleration * delta;
            Projectile.Direction += steeringVector * delta;
        }

        private void OnTimeout()
        {
            ReadyForTargetFinding = true;
        }
    }
}
