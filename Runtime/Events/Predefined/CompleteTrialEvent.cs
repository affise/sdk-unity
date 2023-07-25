using System;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class CompleteTrialEvent : NativeEvent
    {
        public CompleteTrialEvent(): base()
        {}
        public CompleteTrialEvent(string userData): base(userData: userData)
        {}
        public CompleteTrialEvent(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        [Obsolete("use CompleteTrialEvent(userData, timeStampMillis)")]
        public CompleteTrialEvent(JSONObject trial, long timeStampMillis, string userData)
            :base(userData, timeStampMillis)
        {
            AnyData = trial;
        }

        public override string GetName() => EventName.COMPLETE_TRIAL.ToValue();
    }
}