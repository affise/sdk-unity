namespace AffiseAttributionLib.Events.Predefined
{
    public class AddToCartEvent : NativeEvent
    {
        public AddToCartEvent() : base()
        {}
        public AddToCartEvent(string userData) : base(userData: userData)
        {}
        public AddToCartEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.ADD_TO_CART.ToEventName();
    }
}