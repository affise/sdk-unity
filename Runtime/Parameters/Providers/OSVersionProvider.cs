using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Utils;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.OS_VERSION]
     */
    internal class OSVersionProvider : StringPropertyProvider
    {
        public override float Order => 48.0f;
        public override ProviderType? Key => ProviderType.OS_VERSION;
        public override string Provide() => OSUtils.GetOSVersion();
    }
}