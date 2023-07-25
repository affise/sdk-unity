using System;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class ListViewEvent : NativeEvent
    {
        public ListViewEvent(): base()
        {}
        public ListViewEvent(string userData): base(userData: userData)
        {}
        public ListViewEvent(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        [Obsolete("use ListViewEvent(userData, timeStampMillis)")]
        public ListViewEvent(JSONObject list, string userData)
            : base(userData)
        {
            AnyData = list;
        }

        public override string GetName() => EventName.LIST_VIEW.ToValue();
    }
}