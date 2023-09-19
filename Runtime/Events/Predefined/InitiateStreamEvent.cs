namespace AffiseAttributionLib.Events.Predefined
{
    public class InitiateStreamEvent : NativeEvent
    {
        public InitiateStreamEvent() : base()
        {}
        public InitiateStreamEvent(string userData) : base(userData: userData)
        {}
        public InitiateStreamEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.INITIATE_STREAM.ToValue();
    }
}