using Godot;

namespace TopDownDemo.Weapons.Ranged.Projectiles.Spawners.Modifiers
{
    public abstract class Modifier : Node2D
    {
        public abstract void Modify(Projectile projectile);
    }
}
