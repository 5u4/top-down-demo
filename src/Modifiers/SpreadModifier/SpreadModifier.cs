using Godot;
using TopDownDemo.Weapons.Projectiles;

namespace TopDownDemo.Modifiers.SpreadModifier
{
    public class SpreadModifier : Modifier
    {
        [Export] public float Amount;

        public override Projectile Modify(Projectile projectile)
        {
            projectile.Direction = projectile.Direction.Rotated(Mathf.Deg2Rad((float) GD.RandRange(-Amount, Amount)));
            return projectile;
        }
    }
}
