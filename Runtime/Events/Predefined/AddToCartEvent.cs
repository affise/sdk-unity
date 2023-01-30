using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class AddToCartEvent : NativeEvent
    {
        private readonly JSONObject _addToCartObject;
        private readonly long _timeStampMillis;
        private readonly string _userData;

        public AddToCartEvent(JSONObject addToCartObject, long timeStampMillis, string userData)
        {
            _addToCartObject = addToCartObject;
            _timeStampMillis = timeStampMillis;
            _userData = userData;
        }

        public override JSONNode Serialize() => new JSONObject
        {
            ["affise_event_add_to_cart"] = _addToCartObject,
            ["affise_event_add_to_cart_timestamp"] = _timeStampMillis,
        };

        public override string GetName() => "AddToCart";

        public override string GetUserData() => _userData;
    }
}