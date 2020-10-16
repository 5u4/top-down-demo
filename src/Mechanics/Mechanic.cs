using Godot;
using TopDownDemo.Modules.Magazine;
using TopDownDemo.Modules.Reload;
using TopDownDemo.Weapons;

namespace TopDownDemo.Mechanics
{
    public class Mechanic : Node2D
    {
        public Weapon WeaponGetter => GetParent<Weapon>();
        public Magazine MagazineGetter => GetNodeOrNull<Magazine>("Magazine");
        public Reload ReloadGetter => GetNodeOrNull<Reload>("Reload");

        public Weapon Weapon;
        public Magazine Magazine;
        public Reload Reload;

        public override void _Ready()
        {
            Weapon = WeaponGetter;
            Magazine = MagazineGetter;
            Reload = ReloadGetter;
        }
    }
}
