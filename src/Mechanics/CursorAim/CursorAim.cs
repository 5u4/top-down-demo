using Godot;
using TopDownDemo.Weapons;

namespace TopDownDemo.Mechanics.CursorAim
{
    public class CursorAim : Node2D
    {
        public Weapon Weapon;

        public override void _Ready()
        {
            Weapon = GetNode<Weapon>("../..");
        }

        public override void _PhysicsProcess(float delta)
        {
            HandleRotation();
        }

        private void HandleRotation()
        {
            var mouse = GetGlobalMousePosition();
            Weapon.GlobalHandle.LookAt(mouse);
            var angle = Mathf.Rad2Deg((mouse - Weapon.GlobalHandle.GlobalPosition).Angle());
            var shouldFlip = angle <= -90 || angle >= 90;
            var scale = Weapon.GlobalHandle.Scale;
            scale.y = Mathf.Abs(scale.y) * (shouldFlip ? -1 : 1);
            Weapon.GlobalHandle.Scale = scale;
        }
    }
}
