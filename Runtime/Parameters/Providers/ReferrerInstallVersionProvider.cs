using AffiseAttributionLib.AffiseParameters.Base;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.REFERRER_INSTALL_VERSION]
     */
    internal class ReferrerInstallVersionProvider : StringPropertyProvider
    {
        public override float Order => 13.0f;
        public override ProviderType? Key => ProviderType.REFERRER_INSTALL_VERSION;
        public override string Provide() => null;
    }
}