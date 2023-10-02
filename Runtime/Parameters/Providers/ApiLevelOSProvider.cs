using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Utils;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.API_LEVEL_OS]
     */
    internal class ApiLevelOSProvider : StringPropertyProvider
    {
        public override float Order => 46.0f;
        public override ProviderType? Key => ProviderType.API_LEVEL_OS;
        public override string Provide() => OSUtils.GetOSVersion();
    }
}