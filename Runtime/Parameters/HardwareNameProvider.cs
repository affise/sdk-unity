using AffiseAttributionLib.AffiseParameters.Base;
using UnityEngine.Device;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.HARDWARE_NAME]
     */
    internal class HardwareNameProvider : StringPropertyProvider
    {
        public override float Order => 23.0f;
        public override string Key => Parameters.HARDWARE_NAME;
        public override string Provide() => SystemInfo.deviceModel;
    }
}