using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class CompleteStreamEvent : NativeEvent
    {
        private readonly JSONObject _stream;
        private readonly long _timeStampMillis;
        private readonly string _userData;

        public CompleteStreamEvent(JSONObject stream, long timeStampMillis, string userData)
        {
            _stream = stream;
            _timeStampMillis = timeStampMillis;
            _userData = userData;
        }

        public override JSONNode Serialize() => new JSONObject
        {
            ["affise_event_complete_stream"] = _stream,
            ["affise_event_complete_stream_timestamp"] = _timeStampMillis,
        };

        public override string GetName() => "CompleteStream";

        public override string GetUserData() => _userData;
    }
}