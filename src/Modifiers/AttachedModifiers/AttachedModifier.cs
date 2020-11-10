using Godot;
using TopDownDemo.Weapons.Projectiles;

namespace TopDownDemo.Modifiers.AttachedModifiers
{
    public class AttachedModifier : Modifier
    {
        [Export] public PackedScene AttachmentScene;

        public override Projectile Modify(Projectile projectile)
        {
            projectile.AddChild(ModifyAttachment((Attachment) AttachmentScene.Instance()));
            return projectile;
        }

        public virtual Attachment ModifyAttachment(Attachment attachment)
        {
            return attachment;
        }
    }
}
