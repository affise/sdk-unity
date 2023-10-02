namespace AffiseAttributionLib.Events.Predefined
{
    public class OrderItemRemoveEvent : NativeEvent
    {
        public OrderItemRemoveEvent() : base()
        {}
        public OrderItemRemoveEvent(string userData) : base(userData: userData)
        {}
        public OrderItemRemoveEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.ORDER_ITEM_REMOVE.ToEventName();
    }
}