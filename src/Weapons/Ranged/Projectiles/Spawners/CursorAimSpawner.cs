using Godot;

namespace TopDownDemo.Weapons.Ranged.Projectiles.Spawners
{
    public class CursorAimSpawner : Node2D
    {
        [Export] public PackedScene ProjectileScene;
        [Export] public NodePath SpawnPositionPath;
        [Export] public NodePath CenterPositionPath;

        public void Spawn()
        {
            var projectile = (Projectile) ProjectileScene.Instance();
            GetTree().Root.AddChild(projectile);
            projectile.GlobalPosition = GetNode<Node2D>(SpawnPositionPath).GlobalPosition;
            projectile.Direction = (GetGlobalMousePosition() - GetNode<Node2D>(CenterPositionPath).GlobalPosition).Normalized();
        }
    }
}
