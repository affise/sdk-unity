using System;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class AddToCartEvent : NativeEvent
    {
        public AddToCartEvent(): base()
        {}
        public AddToCartEvent(string userData): base(userData: userData)
        {}
        public AddToCartEvent(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        [Obsolete("use AddToCartEvent(userData, timeStampMillis)")]
        public AddToCartEvent(JSONObject addToCartObject, long timeStampMillis, string userData)
            :base(userData, timeStampMillis)
        {
            AnyData = addToCartObject;
        }

        public override string GetName() => EventName.ADD_TO_CART.ToValue();
    }
}