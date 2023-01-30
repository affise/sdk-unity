using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class ShareEvent : NativeEvent
    {
        private readonly JSONObject _share;
        private readonly long _timeStampMillis;
        private readonly string _userData;

        public ShareEvent(JSONObject share, long timeStampMillis, string userData)
        {
            _share = share;
            _timeStampMillis = timeStampMillis;
            _userData = userData;
        }

        public override JSONNode Serialize() => new JSONObject
        {
            ["affise_event_share"] = _share,
            ["affise_event_share_timestamp"] = _timeStampMillis,
        };

        public override string GetName() => "Share";

        public override string GetUserData() => _userData;
    }
}