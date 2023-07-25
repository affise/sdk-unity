using System;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class UnlockAchievementEvent : NativeEvent
    {
        public UnlockAchievementEvent(): base()
        {}
        public UnlockAchievementEvent(string userData): base(userData: userData)
        {}
        public UnlockAchievementEvent(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        [Obsolete("use UnlockAchievementEvent(userData, timeStampMillis)")]
        public UnlockAchievementEvent(JSONObject achievement, long timeStampMillis, string userData)
            :base(userData, timeStampMillis)
        {
            AnyData = achievement;
        }

        public override string GetName() => EventName.UNLOCK_ACHIEVEMENT.ToValue();
    }
}