using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class RateEvent : NativeEvent
    {
        private readonly JSONObject _rate;
        private readonly long _timeStampMillis;
        private readonly string _userData;

        public RateEvent(JSONObject rate, long timeStampMillis, string userData)
        {
            _rate = rate;
            _timeStampMillis = timeStampMillis;
            _userData = userData;
        }

        public override JSONNode Serialize() => new JSONObject
        {
            ["affise_event_rate"] = _rate,
            ["affise_event_rate_timestamp"] = _timeStampMillis,
        };

        public override string GetName() => "Rate";

        public override string GetUserData() => _userData;
    }
}