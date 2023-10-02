namespace AffiseAttributionLib.Events.Predefined
{
    public class SubmitApplicationEvent : NativeEvent
    {
        public SubmitApplicationEvent() : base()
        {}
        public SubmitApplicationEvent(string userData) : base(userData: userData)
        {}
        public SubmitApplicationEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.SUBMIT_APPLICATION.ToEventName();
    }
}