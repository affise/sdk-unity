using AffiseAttributionLib.AffiseParameters.Base;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.DEVICE_MANUFACTURER]
     */
    internal class DeviceManufacturerProvider : StringPropertyProvider
    {
        public override float Order => 24.0f;
        public override ProviderType? Key => ProviderType.DEVICE_MANUFACTURER;
        public override string Provide() => null;
    }
}