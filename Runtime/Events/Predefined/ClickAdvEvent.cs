namespace AffiseAttributionLib.Events.Predefined
{
    public class ClickAdvEvent : NativeEvent
    {
        public ClickAdvEvent() : base()
        {}
        public ClickAdvEvent(string userData) : base(userData: userData)
        {}
        public ClickAdvEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.CLICK_ADV.ToValue();
    }
}