using System;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class TravelBookingEvent : NativeEvent
    {
        public TravelBookingEvent(string userData) : base(userData: userData)
        { }

        public TravelBookingEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        { }

        [Obsolete("use TravelBookingEvent(userData, timeStampMillis)")]
        public TravelBookingEvent(JSONArray details, string userData)
            : base(userData: userData)
        {
            AnyData = details;
        }

        public override string GetName() => EventName.TRAVEL_BOOKING.ToValue();
    }
}