namespace AffiseAttributionLib.Events.Predefined
{
    public class LeadEvent : NativeEvent
    {
        public LeadEvent() : base()
        {}
        public LeadEvent(string userData) : base(userData: userData)
        {}
        public LeadEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.LEAD.ToEventName();
    }
}