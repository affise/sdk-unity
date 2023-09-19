namespace AffiseAttributionLib.Events.Predefined
{
    public class InviteEvent : NativeEvent
    {
        public InviteEvent() : base()
        {}
        public InviteEvent(string userData) : base(userData: userData)
        {}
        public InviteEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.INVITE.ToValue();
    }
}