using Godot;
using TopDownDemo.Weapons.Projectiles;

namespace TopDownDemo.Modifiers.MouseAimModifier
{
    public class MouseAimModifier : Modifier
    {
        public override Projectile Modify(Projectile projectile)
        {
            projectile.Direction = projectile.SourceWeaponDisplay.GlobalPosition.DirectionTo(GetGlobalMousePosition());
            return projectile;
        }
    }
}
