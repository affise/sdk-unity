using AffiseAttributionLib.AffiseParameters.Base;
using UnityEngine.Device;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.DEVICE_NAME]
     */
    internal class DeviceNameProvider : StringPropertyProvider
    {
        public override string Provide() => SystemInfo.deviceName;
    }
}