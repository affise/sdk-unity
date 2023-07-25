namespace AffiseAttributionLib.Events.Predefined
{
    public class DonateEvent: NativeEvent
    {
        public DonateEvent(): base()
        {}
        public DonateEvent(string userData): base(userData: userData)
        {}
        public DonateEvent(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.DONATE.ToValue();
    }
}