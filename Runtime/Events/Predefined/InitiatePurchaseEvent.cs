using System;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class InitiatePurchaseEvent : NativeEvent
    {
        public InitiatePurchaseEvent(): base()
        {}
        public InitiatePurchaseEvent(string userData): base(userData: userData)
        {}
        public InitiatePurchaseEvent(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        [Obsolete("use InitiatePurchaseEvent(userData, timeStampMillis)")]
        public InitiatePurchaseEvent(JSONObject purchaseData, long timeStampMillis, string userData)
            :base(userData, timeStampMillis)
        {
            AnyData = purchaseData;
        }

        public override string GetName() => EventName.INITIATE_PURCHASE.ToValue();
    }
}