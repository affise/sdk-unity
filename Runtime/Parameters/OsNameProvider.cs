using AffiseAttributionLib.AffiseParameters.Base;
using UnityEngine.Device;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.OS_NAME]
     */
    internal class OsNameProvider : StringPropertyProvider
    {
        public override float Order => 43.0f;
        public override string Key => Parameters.OS_NAME;
        public override string Provide() => SystemInfo.operatingSystem;
    }
}