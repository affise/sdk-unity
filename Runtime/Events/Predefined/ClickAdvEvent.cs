using System;

namespace AffiseAttributionLib.Events.Predefined
{
    public class ClickAdvEvent : NativeEvent
    {
        public ClickAdvEvent(): base()
        {}
        public ClickAdvEvent(string userData): base(userData: userData)
        {}
        public ClickAdvEvent(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        [Obsolete("use ClickAdvEvent(userData, timeStampMillis)")]
        public ClickAdvEvent(string advertisement, long timeStampMillis, string userData)
            :base(userData, timeStampMillis)
        {
            AnyData = advertisement;
        }

        public override string GetName() => EventName.CLICK_ADV.ToValue();
    }
}