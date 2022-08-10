using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class ReEngageEvent : NativeEvent
    {
        private readonly string _reEngage;
        private readonly string _userData;

        public ReEngageEvent(string reEngage, string userData)
        {
            _reEngage = reEngage;
            _userData = userData;
        }

        public override JSONNode Serialize() => new JSONObject
        {
            ["affise_event_re_engage"] = _reEngage
        };

        public override string GetName() => "ReEngage";

        public override string GetUserData() => _userData;
    }
}