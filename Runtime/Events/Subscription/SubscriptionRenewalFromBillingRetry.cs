using SimpleJSON;

namespace AffiseAttributionLib.Events.Subscription
{
    public class ConvertedTrialFromRetryEvent : BaseSubscriptionEvent
    {
        public ConvertedTrialFromRetryEvent(JSONObject data, string userData) : base(data, userData)
        {
        }

        public override string Type() => SubscriptionEventName.AFFISE_SUBSCRIPTION_RENEWAL_FROM_BILLING_RETRY.ToValue();

        public override string SubType() => SubscriptionSubType.AFFISE_SUB_CONVERTED_TRIAL_FROM_RETRY.ToValue();
    }
    
    public class ConvertedOfferFromRetryEvent : BaseSubscriptionEvent
    {
        public ConvertedOfferFromRetryEvent(JSONObject data, string userData) : base(data, userData)
        {
        }

        public override string Type() => SubscriptionEventName.AFFISE_SUBSCRIPTION_RENEWAL_FROM_BILLING_RETRY.ToValue();

        public override string SubType() => SubscriptionSubType.AFFISE_SUB_CONVERTED_OFFER_FROM_RETRY.ToValue();
    }
    
    public class RenewedSubscriptionFromRetryEvent : BaseSubscriptionEvent
    {
        public RenewedSubscriptionFromRetryEvent(JSONObject data, string userData) : base(data, userData)
        {
        }

        public override string Type() => SubscriptionEventName.AFFISE_SUBSCRIPTION_RENEWAL_FROM_BILLING_RETRY.ToValue();

        public override string SubType() => SubscriptionSubType.AFFISE_SUB_RENEWED_SUBSCRIPTION_FROM_RETRY.ToValue();
    }
}