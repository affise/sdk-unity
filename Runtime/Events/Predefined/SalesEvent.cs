using System;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class SalesEvent : NativeEvent
    {
        public SalesEvent(): base()
        {}
        public SalesEvent(string userData): base(userData: userData)
        {}
        public SalesEvent(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        [Obsolete("use SalesEvent(userData, timeStampMillis)")]
        public SalesEvent(JSONObject salesData, long timeStampMillis, string userData)
            :base(userData, timeStampMillis)
        {
            AnyData = salesData;
        }

        public override string GetName() => EventName.SALES.ToValue();
    }
}