using Godot;
using TopDownDemo.Cores.Spawner;
using TopDownDemo.Modules.Mechanics.Attacks;
using TopDownDemo.Modules.Mechanics.Magazine;
using TopDownDemo.Modules.Mechanics.Reload;

namespace TopDownDemo.Weapons.Ranged.Pistol
{
    public class SecondaryAttack : Executor
    {
        [Export] public NodePath SpawnerPath;
        [Export] public NodePath ReloadPath;
        [Export] public NodePath MagazinePath;
        [Export] public NodePath AnimationPlayerPath;

        public Spawner Spawner;
        public Reload Reload;
        public Magazine Magazine;
        public AnimationPlayer AnimationPlayer;
        public int MaxSpawnAmount = 3;
        public const string AttackAnimation = "WeaponSecondary";

        public override void _Ready()
        {
            Spawner = GetNode<Spawner>(SpawnerPath);
            Reload = GetNode<Reload>(ReloadPath);
            Magazine = GetNode<Magazine>(MagazinePath);
            AnimationPlayer = GetNode<AnimationPlayer>(AnimationPlayerPath);
        }

        public override void Execute()
        {
            if (Magazine.Amount <= 0 || Reload.ActionLock.IsLocked) return; // TODO: Handle empty magazine sfx
            var amount = Mathf.Min(Magazine.Amount, MaxSpawnAmount);
            Spawner.Amount = amount;
            Magazine.Decrease(amount);
            AnimationPlayer.Play(AttackAnimation);
        }
    }
}
