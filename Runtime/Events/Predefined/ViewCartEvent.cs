using System;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class ViewCartEvent : NativeEvent
    {
        public ViewCartEvent(): base()
        {}
        public ViewCartEvent(string userData): base(userData: userData)
        {}
        public ViewCartEvent(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        [Obsolete("use ViewCartEvent(userData, timeStampMillis)")]
        public ViewCartEvent(JSONObject objects, string userData): base(userData: userData)
        {
            AnyData = objects;
        }

        public override string GetName() => EventName.VIEW_CART.ToValue();
    }
}