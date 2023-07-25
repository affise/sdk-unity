using AffiseAttributionLib.AffiseParameters.Base;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.REFERRER]
     */
    internal class InstallReferrerProvider : StringPropertyProvider
    {
        public override float Order => 34.0f;
        public override string Key => Parameters.REFERRER;
        public override string Provide() => null;
    }
}