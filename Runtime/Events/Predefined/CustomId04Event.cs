namespace AffiseAttributionLib.Events.Predefined
{
    public class CustomId04Event : NativeEvent
    {
        public CustomId04Event() : base()
        {}
        public CustomId04Event(string userData) : base(userData: userData)
        {}
        public CustomId04Event(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.CUSTOM_ID_04.ToValue();
    }
}