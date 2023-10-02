namespace AffiseAttributionLib.Events.Predefined
{
    public class OrderItemAddedEvent : NativeEvent
    {
        public OrderItemAddedEvent() : base()
        {}
        public OrderItemAddedEvent(string userData) : base(userData: userData)
        {}
        public OrderItemAddedEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.ORDER_ITEM_ADDED.ToEventName();
    }
}