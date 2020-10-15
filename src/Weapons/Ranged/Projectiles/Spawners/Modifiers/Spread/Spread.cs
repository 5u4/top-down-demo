using System;
using Godot;

namespace TopDownDemo.Weapons.Ranged.Projectiles.Spawners.Modifiers.Spread
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
