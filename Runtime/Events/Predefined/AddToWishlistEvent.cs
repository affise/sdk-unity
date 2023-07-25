using System;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class AddToWishlistEvent : NativeEvent
    {
        public AddToWishlistEvent(): base()
        {}
        public AddToWishlistEvent(string userData): base(userData: userData)
        {}
        public AddToWishlistEvent(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        [Obsolete("use AddToWishlistEvent(userData, timeStampMillis)")]
        public AddToWishlistEvent(JSONObject wishList, long timeStampMillis, string userData)
            :base(userData, timeStampMillis)
        {
            AnyData = wishList;
        }

        public override string GetName() => EventName.ADD_TO_WISHLIST.ToValue();
    }
}