using AffiseAttributionLib.AffiseParameters.Base;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.REFTOKEN]
     */
    internal class RefTokenProvider : StringPropertyProvider
    {
        public override float Order => 32.0f;
        public override ProviderType? Key => ProviderType.REFTOKEN;
        public override string Provide() => null;
    }
}