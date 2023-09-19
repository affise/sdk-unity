namespace AffiseAttributionLib.Events.Predefined
{
    public class OrderReturnRequestEvent : NativeEvent
    {
        public OrderReturnRequestEvent() : base()
        {}
        public OrderReturnRequestEvent(string userData) : base(userData: userData)
        {}
        public OrderReturnRequestEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.ORDER_RETURN_REQUEST.ToValue();
    }
}