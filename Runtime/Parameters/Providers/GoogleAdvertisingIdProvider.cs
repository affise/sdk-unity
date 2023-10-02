using AffiseAttributionLib.AffiseParameters.Base;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.GAID_ADID]
     */
    internal class GoogleAdvertisingIdProvider : StringPropertyProvider
    {
        public override float Order => 31.3f;
        public override ProviderType? Key => ProviderType.GAID_ADID;
        public override string Provide() => null;
    }
}