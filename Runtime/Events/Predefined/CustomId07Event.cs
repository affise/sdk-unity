namespace AffiseAttributionLib.Events.Predefined
{
    public class CustomId07Event : NativeEvent
    {
        public CustomId07Event() : base()
        {}
        public CustomId07Event(string userData) : base(userData: userData)
        {}
        public CustomId07Event(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.CUSTOM_ID_07.ToValue();
    }
}