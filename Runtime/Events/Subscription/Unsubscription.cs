using SimpleJSON;


namespace AffiseAttributionLib.Events.Subscription
{
    public class UnsubscriptionEvent : BaseSubscriptionEvent
    {
        public UnsubscriptionEvent(JSONObject data, string userData) : base(data, userData)
        {
        }

        public override string Type() => SubscriptionParameters.AFFISE_UNSUBSCRIPTION;

        public override string SubType() => SubscriptionParameters.AFFISE_SUB_UNSUBSCRIPTION;
    }
}