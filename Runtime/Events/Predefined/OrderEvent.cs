namespace AffiseAttributionLib.Events.Predefined
{
    public class OrderEvent : NativeEvent
    {
        public OrderEvent() : base()
        {}
        public OrderEvent(string userData) : base(userData: userData)
        {}
        public OrderEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.ORDER.ToValue();
    }
}