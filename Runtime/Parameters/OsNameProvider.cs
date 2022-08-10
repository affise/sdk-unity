using AffiseAttributionLib.AffiseParameters.Base;
using UnityEngine.Device;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.OS_NAME]
     */
    internal class OsNameProvider : StringPropertyProvider
    {
        public override string Provide() => SystemInfo.operatingSystem;
    }
}