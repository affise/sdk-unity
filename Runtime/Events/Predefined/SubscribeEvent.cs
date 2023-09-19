namespace AffiseAttributionLib.Events.Predefined
{
    public class SubscribeEvent : NativeEvent
    {
        public SubscribeEvent() : base()
        {}
        public SubscribeEvent(string userData) : base(userData: userData)
        {}
        public SubscribeEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.SUBSCRIBE.ToValue();
    }
}