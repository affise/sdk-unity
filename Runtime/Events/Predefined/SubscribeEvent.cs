using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class SubscribeEvent : NativeEvent
    {
        private readonly JSONObject _subscribe;
        private readonly long _timeStampMillis;
        private readonly string _userData;

        public SubscribeEvent(JSONObject subscribe, long timeStampMillis, string userData)
        {
            _subscribe = subscribe;
            _timeStampMillis = timeStampMillis;
            _userData = userData;
        }

        public override JSONNode Serialize() => new JSONObject
        {
            ["affise_event_subscribe"] = _subscribe,
            ["affise_event_subscribe_timestamp"] = _timeStampMillis,
        };

        public override string GetName() => "Subscribe";

        public override string GetUserData() => _userData;
    }
}