using Godot;
using TopDownDemo.Weapons.Ranged.Projectiles;

namespace TopDownDemo.Cores.Spawner.Modifiers
{
    public abstract class Modifier : Node2D
    {
        public abstract void Modify(Projectile projectile);
    }
}
