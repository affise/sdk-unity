using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class UpdateEvent : NativeEvent
    {
        private readonly JSONArray _details;
        private readonly string _userData;

        public UpdateEvent(JSONArray details, string userData)
        {
            _details = details;
            _userData = userData;
        }

        public override JSONNode Serialize() => new JSONObject
        {
            ["affise_event_update"] = _details
        };

        public override string GetName() => "Update";

        public override string GetUserData() => _userData;
    }
}