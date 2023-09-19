namespace AffiseAttributionLib.Events.Predefined
{
    public class AddPaymentInfoEvent : NativeEvent
    {
        public AddPaymentInfoEvent() : base()
        {}
        public AddPaymentInfoEvent(string userData) : base(userData: userData)
        {}
        public AddPaymentInfoEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.ADD_PAYMENT_INFO.ToValue();
    }
}