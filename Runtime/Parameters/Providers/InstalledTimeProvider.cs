using AffiseAttributionLib.AffiseParameters.Base;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.INSTALLED_TIME]
     */
    internal class InstalledTimeProvider : LongPropertyProvider
    {
        public override float Order => 6.0f;
        public override ProviderType? Key => ProviderType.INSTALLED_TIME;
        public override long? Provide() => null;
    }
}