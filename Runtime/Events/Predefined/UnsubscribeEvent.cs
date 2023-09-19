namespace AffiseAttributionLib.Events.Predefined
{
    public class UnsubscribeEvent : NativeEvent
    {
        public UnsubscribeEvent() : base()
        {}
        public UnsubscribeEvent(string userData) : base(userData: userData)
        {}
        public UnsubscribeEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.UNSUBSCRIBE.ToValue();
    }
}