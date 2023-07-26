using System;

namespace AffiseAttributionLib.Events.Subscription
{
    internal enum SubscriptionEventName
    {
        AFFISE_SUBSCRIPTION_ACTIVATION,
        AFFISE_SUBSCRIPTION_CANCELLATION,
        AFFISE_SUBSCRIPTION_ENTERED_BILLING_RETRY,
        AFFISE_SUBSCRIPTION_FIRST_CONVERSION,
        AFFISE_SUBSCRIPTION_REACTIVATION,
        AFFISE_SUBSCRIPTION_RENEWAL,
        AFFISE_SUBSCRIPTION_RENEWAL_FROM_BILLING_RETRY,
        AFFISE_UNSUBSCRIPTION,
    }
    
    internal static class SubscriptionEventNameExt
    {
        public static string ToValue(this SubscriptionEventName type)
        {
            return type switch
            {
                SubscriptionEventName.AFFISE_SUBSCRIPTION_ACTIVATION => "affise_subscription_activation",
                SubscriptionEventName.AFFISE_SUBSCRIPTION_CANCELLATION => "affise_subscription_cancellation",
                SubscriptionEventName.AFFISE_SUBSCRIPTION_ENTERED_BILLING_RETRY => "affise_subscription_entered_billing_retry",
                SubscriptionEventName.AFFISE_SUBSCRIPTION_FIRST_CONVERSION => "affise_subscription_first_conversion",
                SubscriptionEventName.AFFISE_SUBSCRIPTION_REACTIVATION => "affise_subscription_reactivation",
                SubscriptionEventName.AFFISE_SUBSCRIPTION_RENEWAL => "affise_subscription_renewal",
                SubscriptionEventName.AFFISE_SUBSCRIPTION_RENEWAL_FROM_BILLING_RETRY => "affise_subscription_renewal_from_billing_retry",
                SubscriptionEventName.AFFISE_UNSUBSCRIPTION => "affise_unsubscription",
                _ => null
            };
        }
    }
}