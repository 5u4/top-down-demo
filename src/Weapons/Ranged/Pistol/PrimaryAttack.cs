using Godot;
using TopDownDemo.Mechanics.Attacks;
using TopDownDemo.Mechanics.Magazine;
using TopDownDemo.Modules.Reload;

namespace TopDownDemo.Weapons.Ranged.Pistol
{
    public class PrimaryAttack : Attack
    {
        [Export] public NodePath ReloadPath;
        [Export] public NodePath MagazinePath;
        [Export] public NodePath AnimationPlayerPath;

        public Reload Reload;
        public Magazine Magazine;
        public AnimationPlayer AnimationPlayer;

        public override void _Ready()
        {
            Reload = GetNode<Reload>(ReloadPath);
            Magazine = GetNode<Magazine>(MagazinePath);
            AnimationPlayer = GetNode<AnimationPlayer>(AnimationPlayerPath);
        }

        public override void Execute()
        {
            if (Magazine.Amount <= 0 || Reload.ActionLock.IsLocked) return; // TODO: Handle empty magazine sfx
            Magazine.Reduce();
            AnimationPlayer.Play("WeaponPrimary");
        }
    }
}
