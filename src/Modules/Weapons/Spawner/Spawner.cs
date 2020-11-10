using System.Collections.Generic;
using System.Linq;
using Godot;
using TopDownDemo.Modifiers;
using TopDownDemo.Weapons.Projectiles;

namespace TopDownDemo.Modules.Weapons.Spawner
{
    public class Spawner : Node2D
    {
        [Export] public NodePath WeaponModifiersPath = "Modifiers";
        [Export] public NodePath CreatureModifiersPath = "../../../Modifiers";
        [Export] public NodePath MuzzlePath = "../Display/GlobalHandle/LocalHandle/Muzzle";
        [Export] public PackedScene ProjectileScene;

        public Node2D WeaponModifiers;
        public Node2D CreatureModifiers;
        public Position2D Muzzle;

        public override void _Ready()
        {
            WeaponModifiers = GetNode<Node2D>(WeaponModifiersPath);
            CreatureModifiers = GetNode<Node2D>(CreatureModifiersPath);
            Muzzle = GetNode<Position2D>(MuzzlePath);
        }

        public void Spawn()
        {
            PlaceProjectile(CreateModified());
        }

        public void SpawnOriginal()
        {
            PlaceProjectile(CreateOriginal());
        }

        public void PlaceProjectile(Projectile projectile)
        {
            projectile.GlobalPosition = Muzzle.GlobalPosition;
            GetTree().Root.AddChild(projectile);
        }

        public Projectile CreateOriginal()
        {
            return (Projectile)ProjectileScene.Instance();
        }

        public Projectile CreateModified()
        {
            return GetModifiers().Aggregate(CreateOriginal(), (projectile, modifier) => modifier.Modify(projectile));
        }

        public IEnumerable<Modifier> GetModifiers()
        {
            return WeaponModifiers.GetChildren().Cast<Modifier>()
                .Concat(CreatureModifiers.GetChildren().Cast<Modifier>());
        }
    }
}
