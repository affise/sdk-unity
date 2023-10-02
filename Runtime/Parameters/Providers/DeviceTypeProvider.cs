using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Extensions;
using UnityEngine.Device;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.DEVICE_TYPE]
     */
    internal class DeviceTypeProvider : StringPropertyProvider
    {
        public override float Order => 42.0f;
        public override ProviderType? Key => ProviderType.DEVICE_TYPE;
        public override string Provide() => SystemInfo.deviceType.ToCustom();
    }
}