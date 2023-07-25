using System;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class CustomId01Event : NativeEvent
    {
        public CustomId01Event(): base()
        {}
        public CustomId01Event(string userData): base(userData: userData)
        {}
        public CustomId01Event(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        [Obsolete("use CustomId01Event(userData, timeStampMillis)")]
        public CustomId01Event(string custom, long timeStampMillis, string userData)
            :base(userData, timeStampMillis)
        {
            AnyData = custom;
        }

        public override string GetName() => EventName.CUSTOM_ID_01.ToValue();
    }
}