using SimpleJSON;

namespace AffiseAttributionLib.Events.Subscription
{
    public class ConvertedTrialEvent : BaseSubscriptionEvent
    {
        public ConvertedTrialEvent(JSONObject data, string userData) : base(data, userData)
        {
        }

        public override string Type() => SubscriptionParameters.AFFISE_SUBSCRIPTION_FIRST_CONVERSION;

        public override string SubType() => SubscriptionParameters.AFFISE_SUB_CONVERTED_TRIAL;
    }
    
    public class ConvertedOfferEvent : BaseSubscriptionEvent
    {
        public ConvertedOfferEvent(JSONObject data, string userData) : base(data, userData)
        {
        }

        public override string Type() => SubscriptionParameters.AFFISE_SUBSCRIPTION_FIRST_CONVERSION;

        public override string SubType() => SubscriptionParameters.AFFISE_SUB_CONVERTED_OFFER;
    }
}