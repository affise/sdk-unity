using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class ListViewEvent : NativeEvent
    {
        private readonly JSONObject _list;
        private readonly string _userData;

        public ListViewEvent(JSONObject list, string userData)
        {
            _list = list;
            _userData = userData;
        }

        public override JSONNode Serialize() => new JSONObject
        {
            ["affise_event_list_view"] = _list
        };

        public override string GetName() => "ListView";

        public override string GetUserData() => _userData;
    }
}