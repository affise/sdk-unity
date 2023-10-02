namespace AffiseAttributionLib.Events.Predefined
{
    public class CustomId09Event : NativeEvent
    {
        public CustomId09Event() : base()
        {}
        public CustomId09Event(string userData) : base(userData: userData)
        {}
        public CustomId09Event(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.CUSTOM_ID_09.ToEventName();
    }
}