using Godot;

namespace TopDownDemo.Weapons.Projectiles
{
    public abstract class Projectile : Node2D
    {
        [Export] public int Damage = 1;
        [Export] public float Speed = 10;
    }
}
