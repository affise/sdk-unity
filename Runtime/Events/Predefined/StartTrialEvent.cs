using System;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class StartTrialEvent : NativeEvent
    {
        public StartTrialEvent(): base()
        {}
        public StartTrialEvent(string userData): base(userData: userData)
        {}
        public StartTrialEvent(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        [Obsolete("use StartTrialEvent(userData, timeStampMillis)")]
        public StartTrialEvent(JSONObject trial, long timeStampMillis, string userData)
            :base(userData, timeStampMillis)
        {
            AnyData = trial;
        }

        public override string GetName() => EventName.START_TRIAL.ToValue();
    }
}