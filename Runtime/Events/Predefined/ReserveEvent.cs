using System.Collections.Generic;
using System;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class ReserveEvent : NativeEvent
    {
        public ReserveEvent(): base()
        {}
        public ReserveEvent(string userData): base(userData: userData)
        {}
        public ReserveEvent(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        [Obsolete("use ReserveEvent(userData, timeStampMillis)")]
        public ReserveEvent(List<JSONObject> reserve, long timeStampMillis, string userData)
            : base(userData, timeStampMillis)
        {
            AnyData = reserve;
        }

        public override string GetName() => EventName.RESERVE.ToValue();
    }
}