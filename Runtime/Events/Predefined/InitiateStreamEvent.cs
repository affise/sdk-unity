using System;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class InitiateStreamEvent : NativeEvent
    {
        public InitiateStreamEvent(): base()
        {}
        public InitiateStreamEvent(string userData): base(userData: userData)
        {}
        public InitiateStreamEvent(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        [Obsolete("use InitiateStreamEvent(userData, timeStampMillis)")]
        public InitiateStreamEvent(JSONObject stream, long timeStampMillis, string userData)
            :base(userData, timeStampMillis)
        {
            AnyData = stream;
        }

        public override string GetName() => EventName.INITIATE_STREAM.ToValue();
    }
}