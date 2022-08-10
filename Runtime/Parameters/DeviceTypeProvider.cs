using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Extensions;
using UnityEngine.Device;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.DEVICE_TYPE]
     */
    internal class DeviceTypeProvider : StringPropertyProvider
    {
        public override string Provide() => SystemInfo.deviceType.ToCustom();
    }
}