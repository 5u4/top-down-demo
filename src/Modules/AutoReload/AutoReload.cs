using System.Linq;
using Godot;
using TopDownDemo.Mechanics.Magazine;
using TopDownDemo.Mechanics.Reload;

namespace TopDownDemo.Modules.AutoReload
{
    public class AutoReload : Node2D
    {
        [Export] public string[] Triggers = {"weapon_primary", "weapon_secondary"};
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

        public override void _PhysicsProcess(float delta)
        {
            if (!Triggers.Any(Input.IsActionPressed)
                || Magazine.Amount > 0
                // TODO: Use other booleans to identify
                || AnimationPlayer.IsPlaying()) return;
            Reload.StartReloading();
        }
    }
}
