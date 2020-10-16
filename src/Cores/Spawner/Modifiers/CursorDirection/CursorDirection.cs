using Godot;
using TopDownDemo.Weapons.Ranged.Projectiles;

namespace TopDownDemo.Cores.Spawner.Modifiers.CursorDirection
{
    public class CursorDirection : Modifier
    {
        [Export] public NodePath CenterPositionPath;

        public override void Modify(Projectile projectile)
        {
            projectile.Direction = (GetGlobalMousePosition() - GetNode<Node2D>(CenterPositionPath).GlobalPosition).Normalized();
        }
    }
}
