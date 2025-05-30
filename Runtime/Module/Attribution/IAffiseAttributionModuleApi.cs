#nullable enable
using System;
using System.Collections.Generic;
using AffiseAttributionLib.Module.AppsFlyer;
using AffiseAttributionLib.Module.Link;
using AffiseAttributionLib.Module.Subscription;
using AffiseAttributionLib.Modules;

namespace AffiseAttributionLib.Module.Attribution
{
    public interface IAffiseAttributionModuleApi
    {
        internal const string NotSupported = "[Affise] platform not supported";
     
        public IAffiseLinkApi Link { get; }
        public IAffiseAppsFlyerApi AppsFlyer { get; }
        public IAffiseSubscriptionApi Subscription { get; }

        /**
         * Get module status
         */
        public void GetStatus(AffiseModules module, OnKeyValueCallback onComplete);

        /**
         * Manual module start
         */
        public bool ModuleStart(AffiseModules module);

        /**
         * Get installed modules
         */
        public List<AffiseModules> GetModulesInstalled();

        /**
         * Module Link url Resolve
         */
        [Obsolete("use Affise.Module.Link." + nameof(Affise.Module.Link.Resolve) + " instead.")]
        public void LinkResolve(string uri, AffiseLinkCallback callback);

        /**
         * Module Subscription fetch products
         */
        [Obsolete("use Affise.Module.Subscription." + nameof(Affise.Module.Subscription.FetchProducts) + " instead.")]
        public void FetchProducts(List<string> ids, AffiseResultCallback<AffiseProductsResult> callback);

        /**
         * Module Subscription purchase
         */
        [Obsolete("use Affise.Module.Subscription." + nameof(Affise.Module.Subscription.Purchase) + " instead.")]
        public void Purchase(
            AffiseProduct product,
            AffiseProductType type,
            AffiseResultCallback<AffisePurchasedInfo> callback
        );
    }
}