using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class CompleteRegistrationEvent : NativeEvent
    {
        private readonly JSONObject _registration;
        private readonly long _timeStampMillis;
        private readonly string _userData;

        public CompleteRegistrationEvent(JSONObject registration, long timeStampMillis, string userData)
        {
            _registration = registration;
            _timeStampMillis = timeStampMillis;
            _userData = userData;
        }

        public override JSONNode Serialize() => new JSONObject
        {
            ["affise_event_complete_registration"] = _registration,
            ["affise_event_complete_registration_timestamp"] = _timeStampMillis,
        };

        public override string GetName() => "CompleteRegistration";

        public override string GetUserData() => _userData;
    }
}