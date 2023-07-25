using System;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class CustomId04Event : NativeEvent
    {
        public CustomId04Event(): base()
        {}
        public CustomId04Event(string userData): base(userData: userData)
        {}
        public CustomId04Event(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        [Obsolete("use CustomId04Event(userData, timeStampMillis)")]
        public CustomId04Event(string custom, long timeStampMillis, string userData)
            :base(userData, timeStampMillis)
        {
            AnyData = custom;
        }

        public override string GetName() => EventName.CUSTOM_ID_04.ToValue();
    }
}