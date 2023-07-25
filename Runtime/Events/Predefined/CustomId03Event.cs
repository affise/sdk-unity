using System;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class CustomId03Event : NativeEvent
    {
        public CustomId03Event(): base()
        {}
        public CustomId03Event(string userData): base(userData: userData)
        {}
        public CustomId03Event(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        [Obsolete("use CustomId03Event(userData, timeStampMillis)")]
        public CustomId03Event(string custom, long timeStampMillis, string userData)
            :base(userData, timeStampMillis)
        {
            AnyData = custom;
        }

        public override string GetName() => EventName.CUSTOM_ID_03.ToValue();
    }
}