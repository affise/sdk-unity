using AffiseAttributionLib.AffiseParameters.Base;
using UnityEngine.Device;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.DEVICE_NAME]
     */
    internal class DeviceNameProvider : StringPropertyProvider
    {
        public override float Order => 41.0f;
        public override string Key => Parameters.DEVICE_NAME;
        public override string Provide() => SystemInfo.deviceName;
    }
}