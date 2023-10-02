using AffiseAttributionLib.AffiseParameters.Base;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.ISP]
     */
    internal class IspNameProvider : StringPropertyProvider
    {
        public override float Order => 37.1f;
        public override ProviderType? Key => ProviderType.ISP;
        public override string Provide() => null;
    }
}