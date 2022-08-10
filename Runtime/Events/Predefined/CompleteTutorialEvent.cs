using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class CompleteTutorialEvent : NativeEvent
    {
        private readonly JSONObject _tutorial;
        private readonly long _timeStampMillis;
        private readonly string _userData;

        public CompleteTutorialEvent(JSONObject tutorial, long timeStampMillis, string userData)
        {
            _tutorial = tutorial;
            _timeStampMillis = timeStampMillis;
            _userData = userData;
        }

        public override JSONNode Serialize() => new JSONObject
        {
            ["affise_event_complete_tutorial"] = _tutorial,
            ["affise_event_complete_tutorial_timestamp"] = _timeStampMillis,
        };

        public override string GetName() => "CompleteTutorial";

        public override string GetUserData() => _userData;
    }
}