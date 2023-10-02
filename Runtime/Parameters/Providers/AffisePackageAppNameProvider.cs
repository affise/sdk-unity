using AffiseAttributionLib.AffiseParameters.Base;
using UnityEngine;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.AFFISE_PKG_APP_NAME]
     */
    internal class AffisePackageAppNameProvider : StringPropertyProvider
    {
        public override float Order => 2.0f;
        public override ProviderType? Key => ProviderType.AFFISE_PKG_APP_NAME;
        public override string Provide() => Application.identifier;
    }
}