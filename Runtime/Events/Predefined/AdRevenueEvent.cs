namespace AffiseAttributionLib.Events.Predefined
{
    public class AdRevenueEvent: NativeEvent
    {
        public AdRevenueEvent(): base()
        {}
        public AdRevenueEvent(string userData): base(userData: userData)
        {}
        public AdRevenueEvent(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.AD_REVENUE.ToValue();
    }
}