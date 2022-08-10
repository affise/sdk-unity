using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class AchieveLevelEvent : NativeEvent
    {
        private readonly JSONObject _level;
        private readonly long _timeStampMillis;
        private readonly string _userData;

        public AchieveLevelEvent(JSONObject level, long timeStampMillis, string userData)
        {
            _level = level;
            _timeStampMillis = timeStampMillis;
            _userData = userData;
        }

        public override JSONNode Serialize() => new JSONObject
        {
            ["affise_event_achieve_level"] = _level,
            ["affise_event_achieve_level_timestamp"] = _timeStampMillis,
        };

        public override string GetName() => "AchieveLevel";

        public override string GetUserData() => _userData;
    }
}