namespace AffiseAttributionLib.Events.Predefined
{
    public class ShareEvent : NativeEvent
    {
        public ShareEvent() : base()
        {}
        public ShareEvent(string userData) : base(userData: userData)
        {}
        public ShareEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.SHARE.ToValue();
    }
}