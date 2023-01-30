using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class InviteEvent : NativeEvent
    {
        private readonly JSONObject _invite;
        private readonly long _timeStampMillis;
        private readonly string _userData;

        public InviteEvent(JSONObject invite, long timeStampMillis, string userData)
        {
            _invite = invite;
            _timeStampMillis = timeStampMillis;
            _userData = userData;
        }

        public override JSONNode Serialize() => new JSONObject
        {
            ["affise_event_invite"] = _invite,
            ["affise_event_invite_timestamp"] = _timeStampMillis,
        };

        public override string GetName() => "Invite";

        public override string GetUserData() => _userData;
    }
}