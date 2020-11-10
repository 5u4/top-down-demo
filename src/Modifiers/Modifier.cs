using Godot;
using TopDownDemo.Weapons.Projectiles;

namespace TopDownDemo.Modifiers
{
    public abstract class Modifier : Node2D
    {
        public abstract Projectile Modify(Projectile projectile);
    }
}
