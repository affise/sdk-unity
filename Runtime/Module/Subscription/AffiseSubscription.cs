#nullable enable
using System.Collections.Generic;
using AffiseAttributionLib.Module.Attribution;
using AffiseAttributionLib.Modules;

namespace AffiseAttributionLib.Module.Subscription
{
    internal class AffiseSubscription: AffiseModuleApiWrapper<IAffiseSubscriptionApi>, IAffiseModuleSubscriptionApi
    {
        protected override AffiseModules Module => AffiseModules.Subscription;
        
        public void FetchProducts(List<string> ids, AffiseResultCallback<AffiseProductsResult> callback)
        {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
            _native?.FetchProducts(ids, callback);           
#else
            UnityEngine.Debug.LogWarning($"{IAffiseAttributionModuleApi.NotSupported} - FetchProducts");
            callback.Invoke(AffiseResult<AffiseProductsResult>.Failure(IAffiseAttributionModuleApi.NotSupported));
#endif
        }

        public void Purchase(AffiseProduct product, AffiseProductType type, AffiseResultCallback<AffisePurchasedInfo> callback)
        {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
            _native?.Purchase(product, type, callback);
#else               
            UnityEngine.Debug.LogWarning($"{IAffiseAttributionModuleApi.NotSupported} - Purchase");
            callback.Invoke(AffiseResult<AffisePurchasedInfo>.Failure(IAffiseAttributionModuleApi.NotSupported));
#endif
        }
        
        public bool HasModule() => IsModuleInit;
    }
}