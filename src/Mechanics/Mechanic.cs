using Godot;
using TopDownDemo.Weapons;

namespace TopDownDemo.Mechanics
{
    public class Mechanic : Node2D
    {
        public Weapon WeaponGetter => GetParent<Weapon>();
        public Magazine.Magazine MagazineGetter => GetNodeOrNull<Magazine.Magazine>("Magazine");
        public Reload.Reload ReloadGetter => GetNodeOrNull<Reload.Reload>("Reload");

        public Weapon Weapon;
        public Magazine.Magazine Magazine;
        public Reload.Reload Reload;

        public override void _Ready()
        {
            Weapon = WeaponGetter;
            Magazine = MagazineGetter;
            Reload = ReloadGetter;
        }
    }
}
