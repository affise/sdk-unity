using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class TravelBookingEvent : NativeEvent
    {
        private readonly JSONArray _details;
        private readonly string _userData;

        public TravelBookingEvent(JSONArray details, string userData)
        {
            _details = details;
            _userData = userData;
        }

        public override JSONNode Serialize() => new JSONObject
        {
            ["affise_event_travel_booking"] = _details,
        };

        public override string GetName() => "TravelBooking";

        public override string GetUserData() => _userData;
    }
}