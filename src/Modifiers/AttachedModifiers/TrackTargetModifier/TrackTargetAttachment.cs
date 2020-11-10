using Godot;
using TopDownDemo.Creatures;

namespace TopDownDemo.Modifiers.AttachedModifiers.TrackTargetModifier
{
    public class TrackTargetAttachment : Attachment
    {
        [Export] public float Sight = 400;

        public Area2D Area;
        public CollisionShape2D Collision;
        public Creature Target;

        public override void _Ready()
        {
            base._Ready();

            Area = GetNode<Area2D>("Area2D");
            Collision = GetNode<CollisionShape2D>("Area2D/CollisionShape2D");

            Collision.Shape = new CircleShape2D {Radius = Sight};
        }


        public override void _PhysicsProcess(float delta)
        {
            if (Target == null) FindTarget();
            else TrackTarget();
        }

        private void FindTarget()
        {
            foreach (var node in Area.GetOverlappingBodies())
            {
                if (!(node is KinematicBody2D body) || !(body.GetParent() is Creature creature)) continue;
                if (creature.Faction != Faction.None && creature.Faction == Projectile.Faction) continue;
                Target = creature;
                return;
            }
        }

        private void TrackTarget()
        {
            Projectile.Direction = Projectile.GlobalPosition.DirectionTo(Target.GlobalPosition);
        }
    }
}
