#nullable enable
using System;
using AffiseAttributionLib.Referrer;
using AffiseAttributionLib.SKAd;

namespace AffiseAttributionLib.Module.Attribution
{
    public interface IAffiseIOSApi
    {
        /**
         * StoreKit Ad Network register app
         */
        public void RegisterAppForAdNetworkAttribution(ErrorCallback completionHandler);

        /**
         * StoreKit Ad Network updatePostbackConversionValue
         */
        public void UpdatePostbackConversionValue(
            int fineValue,
            CoarseValue coarseValue,
            ErrorCallback completionHandler
        );

        /**
         * Get referrer url
         */
        [Obsolete("use Affise." + nameof(Affise.GetDeferredDeeplink) + " instead.")]
        public void GetReferrerOnServer(OnReferrerCallback callback);

        /**
         * Get referrer value by key
         */
        [Obsolete("use Affise." + nameof(Affise.GetDeferredDeeplinkValue) + " instead.")]
        public void GetReferrerOnServerValue(ReferrerKey key, OnReferrerCallback callback);
    }
}