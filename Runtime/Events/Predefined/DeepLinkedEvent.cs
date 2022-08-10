using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class DeepLinkedEvent : NativeEvent
    {
        private readonly bool _isLinked;
        private readonly string _userData;

        public DeepLinkedEvent(bool isLinked, string userData)
        {
            _isLinked = isLinked;
            _userData = userData;
        }

        public override JSONNode Serialize() => new JSONObject
        {
            ["affise_event_deep_linked"] = _isLinked,
        };

        public override string GetName() => "DeepLinked";

        public override string GetUserData() => _userData;
    }
}