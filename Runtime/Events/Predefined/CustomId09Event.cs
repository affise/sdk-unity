using System;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class CustomId09Event : NativeEvent
    {
        public CustomId09Event(): base()
        {}
        public CustomId09Event(string userData): base(userData: userData)
        {}
        public CustomId09Event(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        [Obsolete("use CustomId09Event(userData, timeStampMillis)")]
        public CustomId09Event(string custom, long timeStampMillis, string userData)
            :base(userData, timeStampMillis)
        {
            AnyData = custom;
        }

        public override string GetName() => EventName.CUSTOM_ID_09.ToValue();
    }
}