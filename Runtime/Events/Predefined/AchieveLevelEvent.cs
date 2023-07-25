using System;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class AchieveLevelEvent : NativeEvent
    {
        public AchieveLevelEvent(): base()
        {}
        public AchieveLevelEvent(string userData): base(userData: userData)
        {}
        public AchieveLevelEvent(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}
        
        [Obsolete("use AchieveLevelEvent(userData, timeStampMillis)")]
        public AchieveLevelEvent(JSONObject level, long timeStampMillis, string userData)
            : base(userData, timeStampMillis)
        {
            AnyData = level;
        }

        public override string GetName() => EventName.ACHIEVE_LEVEL.ToValue();
    }
}