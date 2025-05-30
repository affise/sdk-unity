using System.Collections.Generic;
using AffiseAttributionLib.Modules;

namespace AffiseAttributionLib.Module.Subscription
{
    public interface IAffiseSubscriptionApi : IAffiseModuleApi
    {
        void FetchProducts(List<string> ids, AffiseResultCallback<AffiseProductsResult> callback);

        void Purchase(
            AffiseProduct product,
            AffiseProductType type,
            AffiseResultCallback<AffisePurchasedInfo> callback
        );
    }
}