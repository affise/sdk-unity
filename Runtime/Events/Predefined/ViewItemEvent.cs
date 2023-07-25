using System;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class ViewItemEvent : NativeEvent
    {
        public ViewItemEvent(): base()
        {}
        public ViewItemEvent(string userData): base(userData: userData)
        {}
        public ViewItemEvent(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        [Obsolete("use ViewItemEvent(userData, timeStampMillis)")]
        public ViewItemEvent(JSONObject item, string userData): base(userData: userData)
        {
            AnyData = item;
        }

        public override string GetName() => EventName.VIEW_ITEM.ToValue();
    }
}