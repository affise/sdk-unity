using AffiseAttributionLib.AffiseParameters.Base;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.INSTALLED_HOUR]
     */
    internal class InstalledHourProvider : LongPropertyProvider
    {
        public override float Order => 8.0f;
        public override ProviderType? Key => ProviderType.INSTALLED_HOUR;
        public override long? Provide() => null;
    }
}