using AffiseAttributionLib.AffiseParameters.Base;
using UnityEngine.Device;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.HARDWARE_NAME]
     */
    internal class HardwareNameProvider : StringPropertyProvider
    {
        public override string Provide() => SystemInfo.deviceModel;
    }
}