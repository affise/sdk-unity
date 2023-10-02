using AffiseAttributionLib.AffiseParameters.Base;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.REFERRER]
     */
    internal class InstallReferrerProvider : StringPropertyProvider
    {
        public override float Order => 34.0f;
        public override ProviderType? Key => ProviderType.REFERRER;
        public override string Provide() => null;
    }
}