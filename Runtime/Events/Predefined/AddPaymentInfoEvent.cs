using System;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class AddPaymentInfoEvent : NativeEvent
    {
        public AddPaymentInfoEvent(): base()
        {}
        public AddPaymentInfoEvent(string userData): base(userData: userData)
        {}
        public AddPaymentInfoEvent(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        [Obsolete("use AddPaymentInfoEvent(userData, timeStampMillis)")]
        public AddPaymentInfoEvent(JSONObject paymentInfo, long timeStampMillis, string userData)
            :base(userData, timeStampMillis)
        {
            AnyData = paymentInfo;
        }

        public override string GetName() => EventName.ADD_PAYMENT_INFO.ToValue();
    }
}