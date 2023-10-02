namespace AffiseAttributionLib.Events.Predefined
{
    public class StartRegistrationEvent : NativeEvent
    {
        public StartRegistrationEvent() : base()
        {}
        public StartRegistrationEvent(string userData) : base(userData: userData)
        {}
        public StartRegistrationEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.START_REGISTRATION.ToEventName();
    }
}