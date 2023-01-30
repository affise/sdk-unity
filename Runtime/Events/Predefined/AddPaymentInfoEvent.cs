using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class AddPaymentInfoEvent : NativeEvent
    {
        private readonly JSONObject _paymentInfo;
        private readonly long _timeStampMillis;
        private readonly string _userData;

        public AddPaymentInfoEvent(JSONObject paymentInfo, long timeStampMillis, string userData)
        {
            _paymentInfo = paymentInfo;
            _timeStampMillis = timeStampMillis;
            _userData = userData;
        }

        public override JSONNode Serialize() => new JSONObject
        {
            ["affise_event_add_payment_info"] = _paymentInfo,
            ["affise_event_add_payment_info_timestamp"] = _timeStampMillis,
        };

        public override string GetName() => "AddPaymentInfo";

        public override string GetUserData() => _userData;
    }
}