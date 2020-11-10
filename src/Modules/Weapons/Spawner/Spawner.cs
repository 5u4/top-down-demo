using System.Collections.Generic;
using System.Linq;
using Godot;
using TopDownDemo.Creatures;
using TopDownDemo.Modifiers;
using TopDownDemo.Weapons.Projectiles;

namespace TopDownDemo.Modules.Weapons.Spawner
{
    public class Spawner : Node2D
    {
        [Export] public NodePath CreaturePath = "../../..";
        [Export] public NodePath WeaponDisplayPath = "../Display";
        [Export] public NodePath WeaponModifiersPath = "Modifiers";
        [Export] public NodePath CreatureModifiersPath = "../../../Modifiers";
        [Export] public NodePath MuzzlePath = "../Display/GlobalHandle/LocalHandle/Muzzle";
        [Export] public PackedScene ProjectileScene;

        public Creature Creature;
        public Node2D WeaponDisplay;
        public Node2D WeaponModifiers;
        public Node2D CreatureModifiers;
        public Position2D Muzzle;

        public override void _Ready()
        {
            Creature = GetNode<Creature>(CreaturePath);
            WeaponDisplay = GetNode<Node2D>(WeaponDisplayPath);
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
            var projectile = (Projectile)ProjectileScene.Instance();
            projectile.SourceWeaponDisplay = WeaponDisplay;
            projectile.Faction = Creature.Faction;
            return projectile;
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
