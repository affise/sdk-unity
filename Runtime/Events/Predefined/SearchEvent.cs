using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class SearchEvent : NativeEvent
    {
        private readonly JSONArray _search;
        private readonly long _timeStampMillis;
        private readonly string _userData;

        public SearchEvent(JSONArray search, long timeStampMillis, string userData)
        {
            _search = search;
            _timeStampMillis = timeStampMillis;
            _userData = userData;
        }

        public override JSONNode Serialize() => new JSONObject
        {
            ["affise_event_search"] = _search,
            ["affise_event_search_timestamp"] = _timeStampMillis,
        };

        public override string GetName() => "Search";

        public override string GetUserData() => _userData;
    }
}