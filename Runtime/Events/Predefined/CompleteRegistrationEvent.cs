namespace AffiseAttributionLib.Events.Predefined
{
    public class CompleteRegistrationEvent : NativeEvent
    {
        public CompleteRegistrationEvent() : base()
        {}
        public CompleteRegistrationEvent(string userData) : base(userData: userData)
        {}
        public CompleteRegistrationEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.COMPLETE_REGISTRATION.ToValue();
    }
}