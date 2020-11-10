using Godot;

namespace TopDownDemo.Modifiers.AttachedModifiers.TrackTargetModifier
{
    public class TrackTargetModifier : AttachedModifier
    {
        [Export] public float Sight = 1500;
        [Export] public float SteeringScale = 0.008f;
        [Export] public float SteeringAcceleration = 0.5f;
        [Export] public float TargetFindingInterval = 0.1f;

        public override Attachment ModifyAttachment(Attachment attachment)
        {
            var trackTargetAttachment = (TrackTargetAttachment) attachment;
            trackTargetAttachment.Sight = Sight;
            trackTargetAttachment.SteeringScale = SteeringScale;
            trackTargetAttachment.SteeringAcceleration = SteeringAcceleration;
            trackTargetAttachment.TargetFindingInterval = TargetFindingInterval;
            return trackTargetAttachment;
        }
    }
}
