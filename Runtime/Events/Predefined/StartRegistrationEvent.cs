using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class StartRegistrationEvent : NativeEvent
    {
        private readonly JSONObject _registration;
        private readonly long _timeStampMillis;
        private readonly string _userData;

        public StartRegistrationEvent(JSONObject registration, long timeStampMillis, string userData)
        {
            _registration = registration;
            _timeStampMillis = timeStampMillis;
            _userData = userData;
        }

        public override JSONNode Serialize() => new JSONObject
        {
            ["affise_event_start_registration"] = _registration,
            ["affise_event_start_registration_timestamp"] = _timeStampMillis,
        };

        public override string GetName() => "StartRegistration";

        public override string GetUserData() => _userData;
    }
}