using System;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class ViewAdvEvent : NativeEvent
    {
        public ViewAdvEvent(): base()
        {}
        public ViewAdvEvent(string userData): base(userData: userData)
        {}
        public ViewAdvEvent(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        [Obsolete("use ViewAdvEvent(userData, timeStampMillis)")]
        public ViewAdvEvent(JSONObject ad, long timeStampMillis, string userData)
            :base(userData, timeStampMillis)
        {
            AnyData = ad;
        }

        public override string GetName() => EventName.VIEW_ADV.ToValue();
    }
}