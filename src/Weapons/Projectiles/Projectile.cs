using Godot;
using TopDownDemo.Creatures;

namespace TopDownDemo.Weapons.Projectiles
{
    public abstract class Projectile : Area2D
    {
        [Export] public int Damage = 1;
        [Export] public float Speed = 10;
        [Export] public Vector2 Direction = Vector2.Zero;

        public Node2D SourceWeaponDisplay;
        public Faction Faction = Faction.None;

        public override void _Ready()
        {
            Connect("body_entered", this, nameof(OnBodyEntered));
        }

        public override void _PhysicsProcess(float delta)
        {
            GlobalPosition += Direction.Normalized() * Speed * delta;
        }

        public void Destroy()
        {
            QueueFree();
        }

        private void OnBodyEntered(Node body)
        {
            if (!(body is KinematicBody2D kinematicBody) || !(kinematicBody.GetParent() is Creature creature)) return;
            if (creature.Faction != Faction.None && creature.Faction == Faction) return;
            creature.OnDamaged(Damage);
            Destroy();
        }
    }
}
