using AffiseAttributionLib.AffiseParameters.Base;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.CONNECTION_TYPE]
     */
    internal class ConnectionTypeProvider : StringPropertyProvider
    {
        public override float Order => 21.1f;
        public override ProviderType? Key => ProviderType.CONNECTION_TYPE;
        public override string Provide() => null;
    }
}