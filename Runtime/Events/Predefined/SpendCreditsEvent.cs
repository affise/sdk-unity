using System;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class SpendCreditsEvent : NativeEvent
    {
        public SpendCreditsEvent(): base()
        {}
        public SpendCreditsEvent(string userData): base(userData: userData)
        {}
        public SpendCreditsEvent(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        [Obsolete("use SpendCreditsEvent(userData, timeStampMillis)")]
        public SpendCreditsEvent(long credits, long timeStampMillis, string userData)
            :base(userData, timeStampMillis)
        {
            AnyData = credits;
        }

        public override string GetName() => EventName.SPEND_CREDITS.ToValue();
    }
}