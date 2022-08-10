using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class StartTrialEvent : NativeEvent
    {
        private readonly JSONObject _trial;
        private readonly long _timeStampMillis;
        private readonly string _userData;

        public StartTrialEvent(JSONObject trial, long timeStampMillis, string userData)
        {
            _trial = trial;
            _timeStampMillis = timeStampMillis;
            _userData = userData;
        }

        public override JSONNode Serialize() => new JSONObject
        {
            ["affise_event_start_trial"] = _trial,
            ["affise_event_start_trial_timestamp"] = _timeStampMillis,
        };

        public override string GetName() => "StartTrial";

        public override string GetUserData() => _userData;
    }
}