namespace AffiseAttributionLib.Events.Predefined
{
    public class CustomId08Event : NativeEvent
    {
        public CustomId08Event() : base()
        {}
        public CustomId08Event(string userData) : base(userData: userData)
        {}
        public CustomId08Event(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.CUSTOM_ID_08.ToEventName();
    }
}