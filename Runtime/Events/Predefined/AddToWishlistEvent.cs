using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class AddToWishlistEvent : NativeEvent
    {
        private readonly JSONObject _wishList;
        private readonly long _timeStampMillis;
        private readonly string _userData;

        public AddToWishlistEvent(JSONObject wishList, long timeStampMillis, string userData)
        {
            _wishList = wishList;
            _timeStampMillis = timeStampMillis;
            _userData = userData;
        }

        public override JSONNode Serialize() => new JSONObject
        {
            ["affise_event_add_to_wishlist"] = _wishList,
            ["affise_event_add_to_wishlist_timestamp"] = _timeStampMillis,
        };

        public override string GetName() => "AddToWishlist";

        public override string GetUserData() => _userData;
    }
}