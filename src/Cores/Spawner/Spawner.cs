using Godot;
using TopDownDemo.Cores.Spawner.Modifiers;
using TopDownDemo.Weapons.Projectiles;

namespace TopDownDemo.Cores.Spawner
{
    public class Spawner : Node2D
    {
        [Export] public int Amount = 1;
        [Export] public PackedScene ProjectileScene;
        [Export] public NodePath SpawnPositionPath;

        public void Spawn()
        {
            for (var i = 0; i < Amount; i++) SpawnOne();
        }

        private void SpawnOne()
        {
            var projectile = (Projectile) ProjectileScene.Instance();
            GetTree().Root.AddChild(projectile);
            projectile.GlobalPosition = GetNode<Node2D>(SpawnPositionPath).GlobalPosition;
            ApplyModifiers(projectile);
        }

        private void ApplyModifiers(Projectile projectile)
        {
            foreach (Modifier modifier in GetChildren())
            {
                modifier.Modify(projectile);
            }
        }
    }
}
