namespace AffiseAttributionLib.Events.Predefined
{
    public class CompleteStreamEvent : NativeEvent
    {
        public CompleteStreamEvent() : base()
        {}
        public CompleteStreamEvent(string userData) : base(userData: userData)
        {}
        public CompleteStreamEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.COMPLETE_STREAM.ToValue();
    }
}