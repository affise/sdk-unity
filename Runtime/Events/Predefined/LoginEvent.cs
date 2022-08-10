using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class LoginEvent : NativeEvent
    {
        private readonly JSONObject _login;
        private readonly long _timeStampMillis;
        private readonly string _userData;

        public LoginEvent(JSONObject login, long timeStampMillis, string userData)
        {
            _login = login;
            _timeStampMillis = timeStampMillis;
            _userData = userData;
        }

        public override JSONNode Serialize() => new JSONObject
        {
            ["affise_event_login"] = _login,
            ["affise_event_login_timestamp"] = _timeStampMillis,
        };

        public override string GetName() => "Login";

        public override string GetUserData() => _userData;
    }
}