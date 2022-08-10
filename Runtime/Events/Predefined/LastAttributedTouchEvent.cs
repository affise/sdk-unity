using AffiseAttributionLib.Events.Predefined;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class LastAttributedTouchEvent : NativeEvent
    {
        private readonly TouchType _touchType;
        private readonly long _timeStampMillis;
        private readonly JSONObject _touchData;
        private readonly string _userData;

        public LastAttributedTouchEvent(TouchType touchType, long timeStampMillis, JSONObject touchData,
            string userData)
        {
            _touchType = touchType;
            _timeStampMillis = timeStampMillis;
            _touchData = touchData;
            _userData = userData;
        }

        public override JSONNode Serialize() => new JSONObject
        {
            ["affise_event_last_attributed_touch_type"] = _touchType.ToValue(),
            ["affise_event_last_attributed_touch_timestamp"] = _timeStampMillis,
            ["affise_event_last_attributed_touch_data"] = _touchData,
        };

        public override string GetName() => "LastAttributedTouch";

        public override string GetUserData() => _userData;
    }
}