using System.Collections.Generic;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class ContentItemsViewEvent : NativeEvent
    {
        private readonly List<JSONObject> _objects;
        private readonly string _userData;

        public ContentItemsViewEvent(List<JSONObject> objects, string userData)
        {
            _objects = objects;
            _userData = userData;
        }

        public override JSONNode Serialize()
        {
            var jsonArray = new JSONArray();
            foreach (var o in _objects)
            {
                jsonArray.Add(o);
            }

            return new JSONObject
            {
                ["affise_event_content_items_view"] = jsonArray
            };
        }

        public override string GetName() => "ContentItemsView";

        public override string GetUserData() => _userData;
    }
}