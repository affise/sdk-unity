using SimpleJSON;

namespace AffiseAttributionLib.Events.Subscription
{
    public class ConvertedTrialFromRetryEvent : BaseSubscriptionEvent
    {
        public ConvertedTrialFromRetryEvent(JSONObject data, string userData) : base(data, userData)
        {
        }

        public override string Type() => SubscriptionParameters.AFFISE_SUBSCRIPTION_RENEWAL_FROM_BILLING_RETRY;

        public override string SubType() => SubscriptionParameters.AFFISE_SUB_CONVERTED_TRIAL_FROM_RETRY;
    }
    
    public class ConvertedOfferFromRetryEvent : BaseSubscriptionEvent
    {
        public ConvertedOfferFromRetryEvent(JSONObject data, string userData) : base(data, userData)
        {
        }

        public override string Type() => SubscriptionParameters.AFFISE_SUBSCRIPTION_RENEWAL_FROM_BILLING_RETRY;

        public override string SubType() => SubscriptionParameters.AFFISE_SUB_CONVERTED_OFFER_FROM_RETRY;
    }
    
    public class RenewedSubscriptionFromRetryEvent : BaseSubscriptionEvent
    {
        public RenewedSubscriptionFromRetryEvent(JSONObject data, string userData) : base(data, userData)
        {
        }

        public override string Type() => SubscriptionParameters.AFFISE_SUBSCRIPTION_RENEWAL_FROM_BILLING_RETRY;

        public override string SubType() => SubscriptionParameters.AFFISE_SUB_RENEWED_SUBSCRIPTION_FROM_RETRY;
    }
}