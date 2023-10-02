namespace AffiseAttributionLib.Events.Predefined
{
    public class ViewAdvEvent : NativeEvent
    {
        public ViewAdvEvent() : base()
        {}
        public ViewAdvEvent(string userData) : base(userData: userData)
        {}
        public ViewAdvEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.VIEW_ADV.ToEventName();
    }
}