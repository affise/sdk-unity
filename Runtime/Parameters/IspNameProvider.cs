using AffiseAttributionLib.AffiseParameters.Base;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.ISP]
     */
    internal class IspNameProvider : StringPropertyProvider
    {
        public override float Order => 37.1f;
        public override string Key => Parameters.ISP;
        public override string Provide() => null;
    }
}