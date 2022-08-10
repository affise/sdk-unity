using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class ViewItemEvent : NativeEvent
    {
        private readonly JSONObject _item;
        private readonly string _userData;

        public ViewItemEvent(JSONObject item, string userData)
        {
            _item = item;
            _userData = userData;
        }

        public override JSONNode Serialize() => new JSONObject
        {
            ["affise_event_view_item"] = _item,
        };

        public override string GetName() => "ViewItem";

        public override string GetUserData() => _userData;
    }
}