using System;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class CustomId10Event : NativeEvent
    {
        public CustomId10Event(): base()
        {}
        public CustomId10Event(string userData): base(userData: userData)
        {}
        public CustomId10Event(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        [Obsolete("use CustomId10Event(userData, timeStampMillis)")]
        public CustomId10Event(string custom, long timeStampMillis, string userData)
            :base(userData, timeStampMillis)
        {
            AnyData = custom;
        }

        public override string GetName() => EventName.CUSTOM_ID_10.ToValue();
    }
}