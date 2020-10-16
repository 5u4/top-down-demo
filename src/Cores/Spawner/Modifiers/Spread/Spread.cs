using Godot;
using TopDownDemo.Weapons.Ranged.Projectiles;

namespace TopDownDemo.Cores.Spawner.Modifiers.Spread
{
    public class Spread : Modifier
    {
        [Export] public float Lower;
        [Export] public float Upper;

        public override void Modify(Projectile projectile)
        {
            projectile.Direction = projectile.Direction.Rotated(Mathf.Deg2Rad((float) GD.RandRange(Lower, Upper)));
        }
    }
}
