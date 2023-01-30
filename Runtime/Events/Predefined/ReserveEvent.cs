using System.Collections.Generic;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class ReserveEvent : NativeEvent
    {
        private readonly List<JSONObject> _reserve;
        private readonly long _timeStampMillis;
        private readonly string _userData;

        public ReserveEvent(List<JSONObject> reserve, long timeStampMillis, string userData)
        {
            _reserve = reserve;
            _userData = userData;
        }

        public override JSONNode Serialize() {
            var jsonArray = new JSONArray();
            foreach (var o in _reserve)
            {
                jsonArray.Add(o);
            }
            
            return new JSONObject
            {
                ["affise_event_re_engage"] = jsonArray,
                ["affise_event_rate_timestamp"] = _timeStampMillis,
            };
        }

        public override string GetName() => "Reserve";

        public override string GetUserData() => _userData;
    }
}