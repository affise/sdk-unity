namespace AffiseAttributionLib.Events.Predefined
{
    public class CustomId05Event : NativeEvent
    {
        public CustomId05Event() : base()
        {}
        public CustomId05Event(string userData) : base(userData: userData)
        {}
        public CustomId05Event(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.CUSTOM_ID_05.ToValue();
    }
}