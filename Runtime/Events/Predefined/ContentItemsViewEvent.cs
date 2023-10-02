namespace AffiseAttributionLib.Events.Predefined
{
    public class ContentItemsViewEvent : NativeEvent
    {
        public ContentItemsViewEvent() : base()
        {}
        public ContentItemsViewEvent(string userData) : base(userData: userData)
        {}
        public ContentItemsViewEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.CONTENT_ITEMS_VIEW.ToEventName();
    }
}