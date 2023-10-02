namespace AffiseAttributionLib.Events.Predefined
{
    public class ReserveEvent : NativeEvent
    {
        public ReserveEvent() : base()
        {}
        public ReserveEvent(string userData) : base(userData: userData)
        {}
        public ReserveEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.RESERVE.ToEventName();
    }
}