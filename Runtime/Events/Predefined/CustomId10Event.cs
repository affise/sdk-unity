namespace AffiseAttributionLib.Events.Predefined
{
    public class CustomId10Event : NativeEvent
    {
        public CustomId10Event() : base()
        {}
        public CustomId10Event(string userData) : base(userData: userData)
        {}
        public CustomId10Event(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.CUSTOM_ID_10.ToValue();
    }
}