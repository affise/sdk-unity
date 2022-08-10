using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class ViewItemsEvent : NativeEvent
    {
        private readonly JSONArray _items;
        private readonly string _userData;

        public ViewItemsEvent(JSONArray items, string userData)
        {
            _items = items;
            _userData = userData;
        }

        public override JSONNode Serialize() => new JSONObject
        {
            ["affise_event_view_items"] = _items,
        };

        public override string GetName() => "ViewItems";

        public override string GetUserData() => _userData;
    }
}