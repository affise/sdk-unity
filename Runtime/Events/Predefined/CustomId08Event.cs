using System;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class CustomId08Event : NativeEvent
    {
        public CustomId08Event(): base()
        {}
        public CustomId08Event(string userData): base(userData: userData)
        {}
        public CustomId08Event(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        [Obsolete("use CustomId08Event(userData, timeStampMillis)")]
        public CustomId08Event(string custom, long timeStampMillis, string userData)
            :base(userData, timeStampMillis)
        {
            AnyData = custom;
        }

        public override string GetName() => EventName.CUSTOM_ID_08.ToValue();
    }
}