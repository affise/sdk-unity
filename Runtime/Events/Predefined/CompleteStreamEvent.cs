using System;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class CompleteStreamEvent : NativeEvent
    {
        public CompleteStreamEvent(): base()
        {}
        public CompleteStreamEvent(string userData): base(userData: userData)
        {}
        public CompleteStreamEvent(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        [Obsolete("use CompleteStreamEvent(userData, timeStampMillis)")]
        public CompleteStreamEvent(JSONObject stream, long timeStampMillis, string userData)
            :base(userData, timeStampMillis)
        {
            AnyData = stream;
        }

        public override string GetName() => EventName.COMPLETE_STREAM.ToValue();
    }
}