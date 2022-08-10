using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class UnlockAchievementEvent : NativeEvent
    {
        private readonly JSONObject _achievement;
        private readonly long _timeStampMillis;
        private readonly string _userData;

        public UnlockAchievementEvent(JSONObject achievement, long timeStampMillis, string userData)
        {
            _achievement = achievement;
            _timeStampMillis = timeStampMillis;
            _userData = userData;
        }

        public override JSONNode Serialize() => new JSONObject
        {
            ["affise_event_unlock_achievement"] = _achievement,
            ["affise_event_unlock_achievement_timestamp"] = _timeStampMillis,
        };

        public override string GetName() => "UnlockAchievement";

        public override string GetUserData() => _userData;
    }
}