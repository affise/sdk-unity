using System;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class SubscribeEvent : NativeEvent
    {
        public SubscribeEvent(): base()
        {}
        public SubscribeEvent(string userData): base(userData: userData)
        {}
        public SubscribeEvent(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        [Obsolete("use SubscribeEvent(userData, timeStampMillis)")]
        public SubscribeEvent(JSONObject subscribe, long timeStampMillis, string userData)
            :base(userData, timeStampMillis)
        {
            AnyData = subscribe;
        }

        public override string GetName() => EventName.SUBSCRIBE.ToValue();
    }
}