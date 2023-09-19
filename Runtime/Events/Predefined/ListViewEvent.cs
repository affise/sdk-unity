namespace AffiseAttributionLib.Events.Predefined
{
    public class ListViewEvent : NativeEvent
    {
        public ListViewEvent() : base()
        {}
        public ListViewEvent(string userData) : base(userData: userData)
        {}
        public ListViewEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.LIST_VIEW.ToValue();
    }
}