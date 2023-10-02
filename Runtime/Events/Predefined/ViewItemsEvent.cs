namespace AffiseAttributionLib.Events.Predefined
{
    public class ViewItemsEvent : NativeEvent
    {
        public ViewItemsEvent() : base()
        {}
        public ViewItemsEvent(string userData) : base(userData: userData)
        {}
        public ViewItemsEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.VIEW_ITEMS.ToEventName();
    }
}