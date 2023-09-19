namespace AffiseAttributionLib.Events.Predefined
{
    public class SalesEvent : NativeEvent
    {
        public SalesEvent() : base()
        {}
        public SalesEvent(string userData) : base(userData: userData)
        {}
        public SalesEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.SALES.ToValue();
    }
}