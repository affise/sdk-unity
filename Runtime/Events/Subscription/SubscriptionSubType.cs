namespace AffiseAttributionLib.Events.Subscription
{
    internal enum SubscriptionSubType
    {
        AFFISE_SUB_INITIAL_SUBSCRIPTION,
        AFFISE_SUB_INITIAL_TRIAL,
        AFFISE_SUB_INITIAL_OFFER,
        AFFISE_SUB_FAILED_TRIAL,
        AFFISE_SUB_FAILED_OFFERISE,
        AFFISE_SUB_FAILED_SUBSCRIPTION,
        AFFISE_SUB_FAILED_TRIAL_FROM_RETRY,
        AFFISE_SUB_FAILED_OFFER_FROM_RETRY,
        AFFISE_SUB_FAILED_SUBSCRIPTION_FROM_RETRY,
        AFFISE_SUB_TRIAL_IN_RETRY,
        AFFISE_SUB_OFFER_IN_RETRY,
        AFFISE_SUB_SUBSCRIPTION_IN_RETRY,
        AFFISE_SUB_CONVERTED_TRIAL,
        AFFISE_SUB_CONVERTED_OFFER,
        AFFISE_SUB_REACTIVATED_SUBSCRIPTION,
        AFFISE_SUB_RENEWED_SUBSCRIPTION,
        AFFISE_SUB_CONVERTED_TRIAL_FROM_RETRY,
        AFFISE_SUB_CONVERTED_OFFER_FROM_RETRY,
        AFFISE_SUB_RENEWED_SUBSCRIPTION_FROM_RETRY,
        AFFISE_SUB_UNSUBSCRIPTION,
    }
    
    internal static class SubscriptionSubTypeExt
    {
        public static string ToValue(this SubscriptionSubType type)
        {
            return type switch
            {
                SubscriptionSubType.AFFISE_SUB_INITIAL_SUBSCRIPTION  => "affise_sub_initial_subscription",
                SubscriptionSubType.AFFISE_SUB_INITIAL_TRIAL  => "affise_sub_initial_trial",
                SubscriptionSubType.AFFISE_SUB_INITIAL_OFFER  => "affise_sub_initial_offer",
                SubscriptionSubType.AFFISE_SUB_FAILED_TRIAL  => "affise_sub_failed_trial",
                SubscriptionSubType.AFFISE_SUB_FAILED_OFFERISE  => "affise_sub_failed_offer",
                SubscriptionSubType.AFFISE_SUB_FAILED_SUBSCRIPTION  => "affise_sub_failed_subscription",
                SubscriptionSubType.AFFISE_SUB_FAILED_TRIAL_FROM_RETRY  => "affise_sub_failed_trial_from_retry",
                SubscriptionSubType.AFFISE_SUB_FAILED_OFFER_FROM_RETRY  => "affise_sub_failed_offer_from_retry",
                SubscriptionSubType.AFFISE_SUB_FAILED_SUBSCRIPTION_FROM_RETRY  => "affise_sub_failed_subscription_from_retry",
                SubscriptionSubType.AFFISE_SUB_TRIAL_IN_RETRY  => "affise_sub_trial_in_retry",
                SubscriptionSubType.AFFISE_SUB_OFFER_IN_RETRY  => "affise_sub_offer_in_retry",
                SubscriptionSubType.AFFISE_SUB_SUBSCRIPTION_IN_RETRY  => "affise_sub_subscription_in_retry",
                SubscriptionSubType.AFFISE_SUB_CONVERTED_TRIAL  => "affise_sub_converted_trial",
                SubscriptionSubType.AFFISE_SUB_CONVERTED_OFFER  => "affise_sub_converted_offer",
                SubscriptionSubType.AFFISE_SUB_REACTIVATED_SUBSCRIPTION  => "affise_sub_reactivated_subscription",
                SubscriptionSubType.AFFISE_SUB_RENEWED_SUBSCRIPTION  => "affise_sub_renewed_subscription",
                SubscriptionSubType.AFFISE_SUB_CONVERTED_TRIAL_FROM_RETRY  => "affise_sub_converted_trial_from_retry",
                SubscriptionSubType.AFFISE_SUB_CONVERTED_OFFER_FROM_RETRY  => "affise_sub_converted_offer_from_retry",
                SubscriptionSubType.AFFISE_SUB_RENEWED_SUBSCRIPTION_FROM_RETRY  => "affise_sub_renewed_subscription_from_retry",
                SubscriptionSubType.AFFISE_SUB_UNSUBSCRIPTION  => "affise_sub_unsubscription",
                _ => null
            };
        }
    }
}