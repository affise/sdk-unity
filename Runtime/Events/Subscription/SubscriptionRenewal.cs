using SimpleJSON;

namespace AffiseAttributionLib.Events.Subscription
{
    public class RenewedSubscriptionEvent : BaseSubscriptionEvent
    {
        public RenewedSubscriptionEvent(JSONObject data, string userData) : base(data, userData)
        {
        }

        public override string Type() => SubscriptionEventName.AFFISE_SUBSCRIPTION_RENEWAL.ToValue();

        public override string SubType() => SubscriptionSubType.AFFISE_SUB_RENEWED_SUBSCRIPTION.ToValue();
    }
}