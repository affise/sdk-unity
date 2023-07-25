using AffiseAttributionLib.AffiseParameters.Base;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.REFTOKEN]
     */
    internal class RefTokenProvider : StringPropertyProvider
    {
        public override float Order => 32.0f;
        public override string Key => Parameters.REFTOKEN;
        public override string Provide() => null;
    }
}