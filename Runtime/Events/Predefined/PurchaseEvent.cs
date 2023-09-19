namespace AffiseAttributionLib.Events.Predefined
{
    public class PurchaseEvent : NativeEvent
    {
        public PurchaseEvent() : base()
        {}
        public PurchaseEvent(string userData) : base(userData: userData)
        {}
        public PurchaseEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.PURCHASE.ToValue();
    }
}