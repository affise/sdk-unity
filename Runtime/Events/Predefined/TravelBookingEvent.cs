namespace AffiseAttributionLib.Events.Predefined
{
    public class TravelBookingEvent : NativeEvent
    {
        public TravelBookingEvent() : base()
        {}
        public TravelBookingEvent(string userData) : base(userData: userData)
        {}
        public TravelBookingEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.TRAVEL_BOOKING.ToValue();
    }
}