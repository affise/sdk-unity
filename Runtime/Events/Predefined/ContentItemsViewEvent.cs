using System.Collections.Generic;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class ContentItemsViewEvent : NativeEvent
    {
        public ContentItemsViewEvent(List<JSONObject> objects, string userData)
            : base(userData)
        {
            AnyData = objects;
        }

        public override string GetName() => EventName.CONTENT_ITEMS_VIEW.ToValue();
    }
}