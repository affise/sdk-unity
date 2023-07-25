using SimpleJSON;

namespace AffiseAttributionLib.Events.Subscription
{
    public class TrialInRetryEvent : BaseSubscriptionEvent
    {
        public TrialInRetryEvent(JSONObject data, string userData) : base(data, userData)
        {
        }

        public override string Type() => SubscriptionEventName.AFFISE_SUBSCRIPTION_ENTERED_BILLING_RETRY.ToValue();

        public override string SubType() => SubscriptionSubType.AFFISE_SUB_TRIAL_IN_RETRY.ToValue();
    }

    public class OfferInRetryEvent : BaseSubscriptionEvent
    {
        public OfferInRetryEvent(JSONObject data, string userData) : base(data, userData)
        {
        }

        public override string Type() => SubscriptionEventName.AFFISE_SUBSCRIPTION_ENTERED_BILLING_RETRY.ToValue();

        public override string SubType() => SubscriptionSubType.AFFISE_SUB_OFFER_IN_RETRY.ToValue();
    }

    public class SubscriptionInRetryEvent : BaseSubscriptionEvent
    {
        public SubscriptionInRetryEvent(JSONObject data, string userData) : base(data, userData)
        {
        }

        public override string Type() => SubscriptionEventName.AFFISE_SUBSCRIPTION_ENTERED_BILLING_RETRY.ToValue();

        public override string SubType() => SubscriptionSubType.AFFISE_SUB_SUBSCRIPTION_IN_RETRY.ToValue();
    }
}