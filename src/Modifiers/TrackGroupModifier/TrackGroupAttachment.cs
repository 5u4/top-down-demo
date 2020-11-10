using Godot;

namespace TopDownDemo.Modifiers.TrackGroupModifier
{
    public class TrackGroupAttachment : Attachment
    {
        public Vector2 Direction = Vector2.Zero;

        public override void _Ready()
        {
            base._Ready();
            Direction = Projectile.GlobalPosition.DirectionTo(GetGlobalMousePosition());
        }

        public override void _Process(float delta)
        {
            // TODO: Find target
            Projectile.GlobalPosition += Direction * Projectile.Speed * delta;
        }
    }
}
