using SimpleJSON;

namespace AffiseAttributionLib.Events.Subscription
{
    public class FailedTrialEvent : BaseSubscriptionEvent
    {
        public FailedTrialEvent(JSONObject data, string userData) : base(data, userData)
        {
        }

        public override string Type() => SubscriptionEventName.AFFISE_SUBSCRIPTION_CANCELLATION.ToValue();

        public override string SubType() => SubscriptionSubType.AFFISE_SUB_FAILED_TRIAL.ToValue();
    }

    public class FailedOfferiseEvent : BaseSubscriptionEvent
    {
        public FailedOfferiseEvent(JSONObject data, string userData) : base(data, userData)
        {
        }

        public override string Type() => SubscriptionEventName.AFFISE_SUBSCRIPTION_CANCELLATION.ToValue();

        public override string SubType() => SubscriptionSubType.AFFISE_SUB_FAILED_OFFERISE.ToValue();
    }

    public class FailedSubscriptionEvent : BaseSubscriptionEvent
    {
        public FailedSubscriptionEvent(JSONObject data, string userData) : base(data, userData)
        {
        }

        public override string Type() => SubscriptionEventName.AFFISE_SUBSCRIPTION_CANCELLATION.ToValue();

        public override string SubType() => SubscriptionSubType.AFFISE_SUB_FAILED_SUBSCRIPTION.ToValue();
    }

    public class FailedTrialFromRetryEvent : BaseSubscriptionEvent
    {
        public FailedTrialFromRetryEvent(JSONObject data, string userData) : base(data, userData)
        {
        }

        public override string Type() => SubscriptionEventName.AFFISE_SUBSCRIPTION_CANCELLATION.ToValue();

        public override string SubType() => SubscriptionSubType.AFFISE_SUB_FAILED_TRIAL_FROM_RETRY.ToValue();
    }

    public class FailedOfferFromRetryEvent : BaseSubscriptionEvent
    {
        public FailedOfferFromRetryEvent(JSONObject data, string userData) : base(data, userData)
        {
        }

        public override string Type() => SubscriptionEventName.AFFISE_SUBSCRIPTION_CANCELLATION.ToValue();

        public override string SubType() => SubscriptionSubType.AFFISE_SUB_FAILED_OFFER_FROM_RETRY.ToValue();
    }

    public class FailedSubscriptionFromRetryEvent : BaseSubscriptionEvent
    {
        public FailedSubscriptionFromRetryEvent(JSONObject data, string userData) : base(data, userData)
        {
        }

        public override string Type() => SubscriptionEventName.AFFISE_SUBSCRIPTION_CANCELLATION.ToValue();

        public override string SubType() => SubscriptionSubType.AFFISE_SUB_FAILED_SUBSCRIPTION_FROM_RETRY.ToValue();
    }
}