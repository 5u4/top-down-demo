using Godot;

namespace TopDownDemo.Modifiers.AttachedModifiers.TrackTargetModifier
{
    public class TrackTargetModifier : AttachedModifier
    {
        [Export] public float Sight = 1000;
        [Export] public float SteeringScale = 0.008f;

        public override Attachment ModifyAttachment(Attachment attachment)
        {
            var trackTargetAttachment = (TrackTargetAttachment) attachment;
            trackTargetAttachment.Sight = Sight;
            trackTargetAttachment.SteeringScale = SteeringScale;
            return trackTargetAttachment;
        }
    }
}
