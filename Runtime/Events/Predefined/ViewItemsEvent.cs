using System;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class ViewItemsEvent : NativeEvent
    {
        public ViewItemsEvent(string userData) : base(userData: userData)
        { }

        public ViewItemsEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        { }

        [Obsolete("use ViewItemsEvent(userData, timeStampMillis)")]
        public ViewItemsEvent(JSONArray items, string userData) : base(userData: userData)
        {
            AnyData = items;
        }

        public override string GetName() => EventName.VIEW_ITEMS.ToValue();
    }
}