using Godot;
using TopDownDemo.Weapons.Projectiles;

namespace TopDownDemo.Modifiers.AttachedModifiers
{
    public class AttachedModifier : Modifier
    {
        [Export] public PackedScene AttachmentScene;

        public override Projectile Modify(Projectile projectile)
        {
            projectile.AddChild(AttachmentScene.Instance());
            return projectile;
        }
    }
}
