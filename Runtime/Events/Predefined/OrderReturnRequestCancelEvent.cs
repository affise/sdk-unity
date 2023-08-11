namespace AffiseAttributionLib.Events.Predefined
{
    public class OrderReturnRequestCancelEvent: NativeEvent
    {
        public OrderReturnRequestCancelEvent(): base()
        {}
        public OrderReturnRequestCancelEvent(string userData): base(userData: userData)
        {}
        public OrderReturnRequestCancelEvent(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.ORDER_RETURN_REQUEST_CANCEL.ToValue();
    }
}