namespace AffiseAttributionLib.Events.Predefined
{
    public class SearchEvent : NativeEvent
    {
        public SearchEvent() : base()
        {}
        public SearchEvent(string userData) : base(userData: userData)
        {}
        public SearchEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.SEARCH.ToValue();
    }
}