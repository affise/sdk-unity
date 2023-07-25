using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Extensions;
using UnityEngine.Device;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.PLATFORM]
     */
    internal class PlatformNameProvider : StringPropertyProvider
    {
        public override float Order => 45.0f;
        public override string Key => Parameters.PLATFORM;
        public override string Provide() => Application.platform.ToValue();
    }
}