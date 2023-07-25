using System;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class PurchaseEvent : NativeEvent
    {
        public PurchaseEvent(): base()
        {}
        public PurchaseEvent(string userData): base(userData: userData)
        {}
        public PurchaseEvent(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        [Obsolete("use PurchaseEvent(userData, timeStampMillis)")]
        public PurchaseEvent(JSONObject purchaseData, long timeStampMillis, string userData)
            :base(userData, timeStampMillis)
        {
            AnyData = purchaseData;
        }

        public override string GetName() => EventName.PURCHASE.ToValue();
    }
}