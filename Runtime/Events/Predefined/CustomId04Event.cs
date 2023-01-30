using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class CustomId04Event : NativeEvent
    {
        private readonly string _custom;
        private readonly long _timeStampMillis;
        private readonly string _userData;

        public CustomId04Event(string custom, long timeStampMillis, string userData)
        {
            _custom = custom;
            _timeStampMillis = timeStampMillis;
            _userData = userData;
        }

        public override JSONNode Serialize() => new JSONObject
        {
            ["affise_event_custom_id_04"] = _custom,
            ["affise_event_custom_id_04_timestamp"] = _timeStampMillis,
        };

        public override string GetName() => "CustomId04";

        public override string GetUserData() => _userData;
    }
}