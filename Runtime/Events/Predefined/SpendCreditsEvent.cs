using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class SpendCreditsEvent : NativeEvent
    {
        private readonly long _credits;
        private readonly long _timeStampMillis;
        private readonly string _userData;

        public SpendCreditsEvent(long credits, long timeStampMillis, string userData)
        {
            _credits = credits;
            _timeStampMillis = timeStampMillis;
            _userData = userData;
        }

        public override JSONNode Serialize() => new JSONObject
        {
            ["affise_event_spend_credits"] = _credits,
            ["affise_event_spend_credits_timestamp"] = _timeStampMillis,
        };

        public override string GetName() => "SpendCredits";

        public override string GetUserData() => _userData;
    }
}