using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Utils;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.OS_VERSION]
     */
    internal class OSVersionProvider : StringPropertyProvider
    {
        public override float Order => 48.0f;
        public override string Key => Parameters.OS_VERSION;
        public override string Provide() => OSUtils.GetOSVersion();
    }
}