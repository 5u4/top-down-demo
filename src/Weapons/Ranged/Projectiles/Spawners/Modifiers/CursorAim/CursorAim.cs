using Godot;

namespace TopDownDemo.Weapons.Ranged.Projectiles.Spawners.Modifiers.CursorAim
{
    public class CursorAim : Modifier
    {
        [Export] public NodePath CenterPositionPath;

        public override void Modify(Projectile projectile)
        {
            projectile.Direction = (GetGlobalMousePosition() - GetNode<Node2D>(CenterPositionPath).GlobalPosition).Normalized();
        }
    }
}
