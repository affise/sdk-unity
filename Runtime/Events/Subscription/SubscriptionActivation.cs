using SimpleJSON;

namespace AffiseAttributionLib.Events.Subscription
{
    public class InitialSubscriptionEvent : BaseSubscriptionEvent
    {
        public InitialSubscriptionEvent(JSONObject data, string userData) : base(data, userData)
        {
        }

        public override string Type() => SubscriptionParameters.AFFISE_SUBSCRIPTION_ACTIVATION;

        public override string SubType() => SubscriptionParameters.AFFISE_SUB_INITIAL_SUBSCRIPTION;
    }

    public class InitialTrialEvent : BaseSubscriptionEvent
    {
        public InitialTrialEvent(JSONObject data, string userData) : base(data, userData)
        {
        }

        public override string Type() => SubscriptionParameters.AFFISE_SUBSCRIPTION_ACTIVATION;

        public override string SubType() => SubscriptionParameters.AFFISE_SUB_INITIAL_TRIAL;
    }

    public class InitialOfferEvent : BaseSubscriptionEvent
    {
        public InitialOfferEvent(JSONObject data, string userData) : base(data, userData)
        {
        }

        public override string Type() => SubscriptionParameters.AFFISE_SUBSCRIPTION_ACTIVATION;

        public override string SubType() => SubscriptionParameters.AFFISE_SUB_INITIAL_OFFER;
    }
}