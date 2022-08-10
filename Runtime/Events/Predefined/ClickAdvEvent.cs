using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class ClickAdvEvent : NativeEvent
    {
        private readonly string _advertisement;
        private readonly long _timeStampMillis;
        private readonly string _userData;

        public ClickAdvEvent(string advertisement, long timeStampMillis, string userData)
        {
            _advertisement = advertisement;
            _timeStampMillis = timeStampMillis;
            _userData = userData;
        }

        public override JSONNode Serialize() => new JSONObject
        {
            ["affise_event_click_adv"] = _advertisement,
            ["affise_event_click_adv_timestamp"] = _timeStampMillis,
        };

        public override string GetName() => "ClickAdv";

        public override string GetUserData() => _userData;
    }
}