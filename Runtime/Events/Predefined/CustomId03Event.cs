using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class CustomId03Event : NativeEvent
    {
        private readonly string _custom;
        private readonly long _timeStampMillis;
        private readonly string _userData;

        public CustomId03Event(string custom, long timeStampMillis, string userData)
        {
            _custom = custom;
            _timeStampMillis = timeStampMillis;
            _userData = userData;
        }

        public override JSONNode Serialize() => new JSONObject
        {
            ["affise_event_custom_id_03"] = _custom,
            ["affise_event_custom_id_03_timestamp"] = _timeStampMillis,
        };

        public override string GetName() => "CustomId03";

        public override string GetUserData() => _userData;
    }
}