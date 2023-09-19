namespace AffiseAttributionLib.Events.Predefined
{
    public class ViewCartEvent : NativeEvent
    {
        public ViewCartEvent() : base()
        {}
        public ViewCartEvent(string userData) : base(userData: userData)
        {}
        public ViewCartEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.VIEW_CART.ToValue();
    }
}