using System;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class RateEvent : NativeEvent
    {
        public RateEvent(): base()
        {}
        public RateEvent(string userData): base(userData: userData)
        {}
        public RateEvent(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        [Obsolete("use RateEvent(userData, timeStampMillis)")]
        public RateEvent(JSONObject rate, long timeStampMillis, string userData)
            :base(userData, timeStampMillis)
        {
            AnyData = rate;
        }

        public override string GetName() => EventName.RATE.ToValue();
    }
}