using AffiseAttributionLib.AffiseParameters.Base;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.REFERRER_INSTALL_VERSION]
     */
    internal class ReferrerInstallVersionProvider : StringPropertyProvider
    {
        public override float Order => 13.0f;
        public override string Key => Parameters.REFERRER_INSTALL_VERSION;
        public override string Provide() => null;
    }
}