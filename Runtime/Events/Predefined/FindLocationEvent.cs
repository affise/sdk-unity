namespace AffiseAttributionLib.Events.Predefined
{
    public class FindLocationEvent : NativeEvent
    {
        public FindLocationEvent() : base()
        {}
        public FindLocationEvent(string userData) : base(userData: userData)
        {}
        public FindLocationEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.FIND_LOCATION.ToValue();
    }
}