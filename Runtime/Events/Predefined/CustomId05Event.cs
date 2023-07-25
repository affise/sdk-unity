using System;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class CustomId05Event : NativeEvent
    {
        public CustomId05Event(): base()
        {}
        public CustomId05Event(string userData): base(userData: userData)
        {}
        public CustomId05Event(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        [Obsolete("use CustomId05Event(userData, timeStampMillis)")]
        public CustomId05Event(string custom, long timeStampMillis, string userData)
            :base(userData, timeStampMillis)
        {
            AnyData = custom;
        }

        public override string GetName() => EventName.CUSTOM_ID_05.ToValue();
    }
}