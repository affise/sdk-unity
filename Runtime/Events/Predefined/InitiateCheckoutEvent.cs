namespace AffiseAttributionLib.Events.Predefined
{
    public class InitiateCheckoutEvent: NativeEvent
    {
        public InitiateCheckoutEvent(): base()
        {}
        public InitiateCheckoutEvent(string userData): base(userData: userData)
        {}
        public InitiateCheckoutEvent(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.INITIATE_CHECKOUT.ToValue();
    }
}