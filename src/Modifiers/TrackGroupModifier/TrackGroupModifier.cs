using Godot;
using TopDownDemo.Weapons.Projectiles;

namespace TopDownDemo.Modifiers.TrackGroupModifier
{
    public class TrackGroupModifier : Modifier
    {
        [Export] public PackedScene AttachmentScene;

        public override Projectile Modify(Projectile projectile)
        {
            projectile.AddChild(AttachmentScene.Instance());
            return projectile;
        }
    }
}
