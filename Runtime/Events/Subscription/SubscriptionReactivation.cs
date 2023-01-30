using SimpleJSON;

namespace AffiseAttributionLib.Events.Subscription
{
    public class ReactivatedSubscriptionEvent : BaseSubscriptionEvent
    {
        public ReactivatedSubscriptionEvent(JSONObject data, string userData) : base(data, userData)
        {
        }

        public override string Type() => SubscriptionParameters.AFFISE_SUBSCRIPTION_REACTIVATION;

        public override string SubType() => SubscriptionParameters.AFFISE_SUB_REACTIVATED_SUBSCRIPTION;
    }
}