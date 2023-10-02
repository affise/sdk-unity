using AffiseAttributionLib.AffiseParameters.Base;
using UnityEngine.Device;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.DEVICE_NAME]
     */
    internal class DeviceNameProvider : StringPropertyProvider
    {
        public override float Order => 41.0f;
        public override ProviderType? Key => ProviderType.DEVICE_NAME;
        public override string Provide() => SystemInfo.deviceName;
    }
}