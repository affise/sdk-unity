using AffiseAttributionLib.AffiseParameters.Base;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.DEVICE_MANUFACTURER]
     */
    internal class DeviceManufacturerProvider : StringPropertyProvider
    {
        public override float Order => 24.0f;
        public override string Key => Parameters.DEVICE_MANUFACTURER;
        public override string Provide() => null;
    }
}