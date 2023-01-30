using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class CustomId10Event : NativeEvent
    {
        private readonly string _custom;
        private readonly long _timeStampMillis;
        private readonly string _userData;

        public CustomId10Event(string custom, long timeStampMillis, string userData)
        {
            _custom = custom;
            _timeStampMillis = timeStampMillis;
            _userData = userData;
        }

        public override JSONNode Serialize() => new JSONObject
        {
            ["affise_event_custom_id_10"] = _custom,
            ["affise_event_custom_id_10_timestamp"] = _timeStampMillis,
        };

        public override string GetName() => "CustomId10";

        public override string GetUserData() => _userData;
    }
}