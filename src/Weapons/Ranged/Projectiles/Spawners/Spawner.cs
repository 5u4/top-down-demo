using Godot;
using TopDownDemo.Weapons.Ranged.Projectiles.Spawners.Modifiers;

namespace TopDownDemo.Weapons.Ranged.Projectiles.Spawners
{
    public class Spawner : Node2D
    {
        [Export] public PackedScene ProjectileScene;
        [Export] public NodePath SpawnPositionPath;

        public void Spawn()
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
