namespace AffiseAttributionLib.Events.Predefined
{
    public class ViewItemEvent : NativeEvent
    {
        public ViewItemEvent() : base()
        {}
        public ViewItemEvent(string userData) : base(userData: userData)
        {}
        public ViewItemEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.VIEW_ITEM.ToEventName();
    }
}