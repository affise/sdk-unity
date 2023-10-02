using AffiseAttributionLib.AffiseParameters.Base;
using UnityEngine.Device;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.HARDWARE_NAME]
     */
    internal class HardwareNameProvider : StringPropertyProvider
    {
        public override float Order => 23.0f;
        public override ProviderType? Key => ProviderType.HARDWARE_NAME;
        public override string Provide() => SystemInfo.deviceModel;
    }
}