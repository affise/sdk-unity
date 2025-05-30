#nullable enable
using System;
using AffiseAttributionLib.Referrer;
using AffiseAttributionLib.SKAd;
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
using AffiseAttributionLib.Native;
#endif

namespace AffiseAttributionLib.Module.Attribution
{
    internal class AffiseModuleIso : IAffiseIOSApi
    {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
        private IAffiseNative? _native => Affise._native;
#endif
        
        /**
         * StoreKit Ad Network register app
         */
        public void RegisterAppForAdNetworkAttribution(ErrorCallback completionHandler)
        {
#if (UNITY_IOS) && !UNITY_EDITOR
            _native?.RegisterAppForAdNetworkAttribution(completionHandler);
#else
            completionHandler.Invoke(IAffiseAttributionModuleApi.NotSupported);
#endif
        }

        /**
         * StoreKit Ad Network updatePostbackConversionValue
         */
        public void UpdatePostbackConversionValue(int fineValue, CoarseValue coarseValue, ErrorCallback completionHandler)
        {
#if (UNITY_IOS) && !UNITY_EDITOR
            _native?.UpdatePostbackConversionValue(fineValue, coarseValue, completionHandler);
#else
            completionHandler.Invoke(IAffiseAttributionModuleApi.NotSupported);
#endif
        }
            
        /**
         * Get referrer url
         */
        [Obsolete("use Affise." + nameof(Affise.GetDeferredDeeplink) + " instead.")]
        public void GetReferrerOnServer(OnReferrerCallback callback)
        {
            Affise.GetDeferredDeeplink(callback);
        }

        /**
             * Get referrer value by key
             */
        [Obsolete("use Affise." + nameof(Affise.GetDeferredDeeplinkValue) + " instead.")]
        public void GetReferrerOnServerValue(ReferrerKey key, OnReferrerCallback callback)
        {
            Affise.GetDeferredDeeplinkValue(key, callback);
        }
    }
}