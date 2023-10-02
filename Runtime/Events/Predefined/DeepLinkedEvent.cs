namespace AffiseAttributionLib.Events.Predefined
{
    public class DeepLinkedEvent : NativeEvent
    {
        public DeepLinkedEvent() : base()
        {}
        public DeepLinkedEvent(string userData) : base(userData: userData)
        {}
        public DeepLinkedEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.DEEP_LINKED.ToEventName();
    }
}