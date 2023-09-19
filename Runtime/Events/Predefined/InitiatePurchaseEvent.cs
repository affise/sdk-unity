namespace AffiseAttributionLib.Events.Predefined
{
    public class InitiatePurchaseEvent : NativeEvent
    {
        public InitiatePurchaseEvent() : base()
        {}
        public InitiatePurchaseEvent(string userData) : base(userData: userData)
        {}
        public InitiatePurchaseEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.INITIATE_PURCHASE.ToValue();
    }
}