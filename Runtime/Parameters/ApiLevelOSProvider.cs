using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Utils;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.API_LEVEL_OS]
     */
    internal class ApiLevelOSProvider : StringPropertyProvider
    {
        public override float Order => 46.0f;
        public override string Key => Parameters.API_LEVEL_OS;
        public override string Provide() => OSUtils.GetOSVersion();
    }
}