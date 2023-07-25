using System;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class CompleteTutorialEvent : NativeEvent
    {
        public CompleteTutorialEvent(): base()
        {}
        public CompleteTutorialEvent(string userData): base(userData: userData)
        {}
        public CompleteTutorialEvent(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        [Obsolete("use CompleteTutorialEvent(userData, timeStampMillis)")]
        public CompleteTutorialEvent(JSONObject tutorial, long timeStampMillis, string userData)
            :base(userData, timeStampMillis)
        {
            AnyData = tutorial;
        }

        public override string GetName() => EventName.COMPLETE_TUTORIAL.ToValue();
    }
}