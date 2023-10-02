using AffiseAttributionLib.AffiseParameters.Base;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.INSTALL_BEGIN_TIME]
     */
    internal class InstallBeginTimeProvider : LongPropertyProvider
    {
        public override float Order => 11.0f;
        public override ProviderType? Key => ProviderType.INSTALL_BEGIN_TIME;
        public override long? Provide() => null;
    }
}