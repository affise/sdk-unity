namespace AffiseAttributionLib.Events.Predefined
{
    public class OrderCancelEvent : NativeEvent
    {
        public OrderCancelEvent() : base()
        {}
        public OrderCancelEvent(string userData) : base(userData: userData)
        {}
        public OrderCancelEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.ORDER_CANCEL.ToValue();
    }
}