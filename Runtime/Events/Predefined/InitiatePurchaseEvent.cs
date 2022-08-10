using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class InitiatePurchaseEvent : NativeEvent
    {
        private readonly JSONObject _purchaseData;
        private readonly long _timeStampMillis;
        private readonly string _userData;

        public InitiatePurchaseEvent(JSONObject purchaseData, long timeStampMillis, string userData)
        {
            _purchaseData = purchaseData;
            _timeStampMillis = timeStampMillis;
            _userData = userData;
        }

        public override JSONNode Serialize() => new JSONObject
        {
            ["affise_event_initiate_purchase"] = _purchaseData,
            ["affise_event_initiate_purchase_timestamp"] = _timeStampMillis,
        };

        public override string GetName() => "InitiatePurchase";

        public override string GetUserData() => _userData;
    }
}