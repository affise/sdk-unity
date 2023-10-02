namespace AffiseAttributionLib.Events.Predefined
{
    public class LoginEvent : NativeEvent
    {
        public LoginEvent() : base()
        {}
        public LoginEvent(string userData) : base(userData: userData)
        {}
        public LoginEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.LOGIN.ToEventName();
    }
}