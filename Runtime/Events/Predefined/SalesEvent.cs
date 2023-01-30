using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class SalesEvent : NativeEvent
    {
        private readonly JSONObject _salesData;
        private readonly long _timeStampMillis;
        private readonly string _userData;

        public SalesEvent(JSONObject salesData, long timeStampMillis, string userData)
        {
            _salesData = salesData;
            _timeStampMillis = timeStampMillis;
            _userData = userData;
        }

        public override JSONNode Serialize() => new JSONObject
        {
            ["affise_event_sales"] = _salesData,
            ["affise_event_sales_timestamp"] = _timeStampMillis,
        };

        public override string GetName() => "Sales";

        public override string GetUserData() => _userData;
    }
}