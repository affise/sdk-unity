using System;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class UnsubscribeEvent : NativeEvent
    {
        public UnsubscribeEvent(): base()
        {}
        public UnsubscribeEvent(string userData): base(userData: userData)
        {}
        public UnsubscribeEvent(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        [Obsolete("use UnsubscribeEvent(userData, timeStampMillis)")]
        public UnsubscribeEvent(JSONObject unsubscribe, long timeStampMillis, string userData)
            :base(userData, timeStampMillis)
        {
            AnyData = unsubscribe;
        }

        public override string GetName() => EventName.UNSUBSCRIBE.ToValue();
    }
}