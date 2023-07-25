using System;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class StartTutorialEvent : NativeEvent
    {
        public StartTutorialEvent(): base()
        {}
        public StartTutorialEvent(string userData): base(userData: userData)
        {}
        public StartTutorialEvent(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        [Obsolete("use StartTutorialEvent(userData, timeStampMillis)")]
        public StartTutorialEvent(JSONObject tutorial, long timeStampMillis, string userData)
            :base(userData, timeStampMillis)
        {
            AnyData = tutorial;
        }

        public override string GetName() => EventName.START_TUTORIAL.ToValue();
    }
}