namespace AffiseAttributionLib.Events.Predefined
{
    public class CustomId02Event : NativeEvent
    {
        public CustomId02Event() : base()
        {}
        public CustomId02Event(string userData) : base(userData: userData)
        {}
        public CustomId02Event(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.CUSTOM_ID_02.ToEventName();
    }
}