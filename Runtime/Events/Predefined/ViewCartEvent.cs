using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class ViewCartEvent : NativeEvent
    {
        private readonly JSONObject _objects;
        private readonly string _userData;

        public ViewCartEvent(JSONObject objects, string userData)
        {
            _objects = objects;
            _userData = userData;
        }

        public override JSONNode Serialize() => new JSONObject
        {
            ["affise_event_view_cart"] = _objects,
        };

        public override string GetName() => "ViewCart";

        public override string GetUserData() => _userData;
    }
}