using System;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class ShareEvent : NativeEvent
    {
        public ShareEvent(): base()
        {}
        public ShareEvent(string userData): base(userData: userData)
        {}
        public ShareEvent(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        [Obsolete("use ShareEvent(userData, timeStampMillis)")]
        public ShareEvent(JSONObject share, long timeStampMillis, string userData)
            :base(userData, timeStampMillis)
        {
            AnyData = share;
        }

        public override string GetName() => EventName.SHARE.ToValue();
    }
}