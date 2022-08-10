using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class UnsubscribeEvent : NativeEvent
    {
        private readonly JSONObject _unsubscribe;
        private readonly long _timeStampMillis;
        private readonly string _userData;

        public UnsubscribeEvent(JSONObject unsubscribe, long timeStampMillis, string userData)
        {
            _unsubscribe = unsubscribe;
            _timeStampMillis = timeStampMillis;
            _userData = userData;
        }

        public override JSONNode Serialize() => new JSONObject
        {
            ["affise_event_unsubscribe"] = _unsubscribe,
            ["affise_event_unsubscribe_timestamp"] = _timeStampMillis,
        };

        public override string GetName() => "Unsubscribe";

        public override string GetUserData() => _userData;
    }
}