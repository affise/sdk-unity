using AffiseAttributionLib.AffiseParameters.Base;
using UnityEngine;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.APP_VERSION_RAW]
     */
    internal class AppVersionRawProvider : StringPropertyProvider
    {
        public override float Order => 4.0f;
        public override ProviderType? Key => ProviderType.APP_VERSION_RAW;
        public override string Provide() => Application.version;
    }
}