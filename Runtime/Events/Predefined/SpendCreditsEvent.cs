namespace AffiseAttributionLib.Events.Predefined
{
    public class SpendCreditsEvent : NativeEvent
    {
        public SpendCreditsEvent() : base()
        {}
        public SpendCreditsEvent(string userData) : base(userData: userData)
        {}
        public SpendCreditsEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.SPEND_CREDITS.ToEventName();
    }
}