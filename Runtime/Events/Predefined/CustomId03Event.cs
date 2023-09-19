namespace AffiseAttributionLib.Events.Predefined
{
    public class CustomId03Event : NativeEvent
    {
        public CustomId03Event() : base()
        {}
        public CustomId03Event(string userData) : base(userData: userData)
        {}
        public CustomId03Event(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.CUSTOM_ID_03.ToValue();
    }
}