using AffiseAttributionLib.AffiseParameters.Base;
using UnityEngine;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.APP_VERSION]
     */
    internal class AppVersionProvider : StringPropertyProvider
    {
        public override float Order => 3.0f;
        public override ProviderType? Key => ProviderType.APP_VERSION;
        public override string Provide() => Application.version;
    }
}