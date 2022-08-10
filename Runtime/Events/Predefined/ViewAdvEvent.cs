using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class ViewAdvEvent : NativeEvent
    {
        private readonly JSONObject _ad;
        private readonly long _timeStampMillis;
        private readonly string _userData;

        public ViewAdvEvent(JSONObject ad, long timeStampMillis, string userData)
        {
            _ad = ad;
            _timeStampMillis = timeStampMillis;
            _userData = userData;
        }

        public override JSONNode Serialize() => new JSONObject
        {
            ["affise_event_view_adv"] = _ad,
            ["affise_event_view_adv_timestamp"] = _timeStampMillis,
        };

        public override string GetName() => "ViewAdv";

        public override string GetUserData() => _userData;
    }
}