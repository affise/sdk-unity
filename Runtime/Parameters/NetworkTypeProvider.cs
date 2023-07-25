using AffiseAttributionLib.AffiseParameters.Base;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.NETWORK_TYPE]
     */
    internal class NetworkTypeProvider : StringPropertyProvider
    {
        public override float Order => 23.1f;
        public override string Key => Parameters.NETWORK_TYPE;
        public override string Provide() => null;
    }
}