namespace AffiseAttributionLib.Events.Predefined
{
    public class ViewContentEvent : NativeEvent
    {
        public ViewContentEvent() : base()
        {}
        public ViewContentEvent(string userData) : base(userData: userData)
        {}
        public ViewContentEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.VIEW_CONTENT.ToEventName();
    }
}