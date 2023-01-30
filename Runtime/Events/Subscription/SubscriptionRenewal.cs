using SimpleJSON;

namespace AffiseAttributionLib.Events.Subscription
{
    public class RenewedSubscriptionEvent : BaseSubscriptionEvent
    {
        public RenewedSubscriptionEvent(JSONObject data, string userData) : base(data, userData)
        {
        }

        public override string Type() => SubscriptionParameters.AFFISE_SUBSCRIPTION_RENEWAL;

        public override string SubType() => SubscriptionParameters.AFFISE_SUB_RENEWED_SUBSCRIPTION;
    }
}