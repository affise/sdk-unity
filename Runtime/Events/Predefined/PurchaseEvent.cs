using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class PurchaseEvent : NativeEvent
    {
        private readonly JSONObject _purchaseData;
        private readonly long _timeStampMillis;
        private readonly string _userData;

        public PurchaseEvent(JSONObject purchaseData, long timeStampMillis, string userData)
        {
            _purchaseData = purchaseData;
            _timeStampMillis = timeStampMillis;
            _userData = userData;
        }

        public override JSONNode Serialize() => new JSONObject
        {
            ["affise_event_purchase"] = _purchaseData,
            ["affise_event_purchase_timestamp"] = _timeStampMillis,
        };

        public override string GetName() => "Purchase";

        public override string GetUserData() => _userData;
    }
}