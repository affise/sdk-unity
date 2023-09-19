namespace AffiseAttributionLib.Events.Predefined
{
    public class UpdateEvent : NativeEvent
    {
        public UpdateEvent() : base()
        {}
        public UpdateEvent(string userData) : base(userData: userData)
        {}
        public UpdateEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.UPDATE.ToValue();
    }
}