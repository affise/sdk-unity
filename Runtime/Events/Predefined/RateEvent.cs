namespace AffiseAttributionLib.Events.Predefined
{
    public class RateEvent : NativeEvent
    {
        public RateEvent() : base()
        {}
        public RateEvent(string userData) : base(userData: userData)
        {}
        public RateEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.RATE.ToValue();
    }
}