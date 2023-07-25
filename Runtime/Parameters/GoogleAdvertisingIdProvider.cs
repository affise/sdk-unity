using AffiseAttributionLib.AffiseParameters.Base;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.GAID_ADID]
     */
    internal class GoogleAdvertisingIdProvider : StringPropertyProvider
    {
        public override float Order => 31.3f;
        public override string Key => Parameters.GAID_ADID;
        public override string Provide() => null;
    }
}