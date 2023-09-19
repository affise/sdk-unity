namespace AffiseAttributionLib.Events.Predefined
{
    public class CustomizeProductEvent : NativeEvent
    {
        public CustomizeProductEvent() : base()
        {}
        public CustomizeProductEvent(string userData) : base(userData: userData)
        {}
        public CustomizeProductEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.CUSTOMIZE_PRODUCT.ToValue();
    }
}