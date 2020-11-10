using Godot;

namespace TopDownDemo.Modifiers.AttachedModifiers.SelfDestroyModifier
{
    public class SelfDestroyModifier : AttachedModifier
    {
        [Export] public float LiveTime = 1;

        public override Attachment ModifyAttachment(Attachment attachment)
        {
            var selfDestroyAttachment = (SelfDestroyAttachment) attachment;
            selfDestroyAttachment.LiveTime = LiveTime;
            return selfDestroyAttachment;
        }
    }
}
