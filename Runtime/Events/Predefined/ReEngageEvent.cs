namespace AffiseAttributionLib.Events.Predefined
{
    public class ReEngageEvent : NativeEvent
    {
        public ReEngageEvent() : base()
        {}
        public ReEngageEvent(string userData) : base(userData: userData)
        {}
        public ReEngageEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.RE_ENGAGE.ToValue();
    }
}