using AffiseAttributionLib.AffiseParameters.Base;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provides connection type [Parameters.CONNECTION_TYPE]
     */
    internal class ConnectionTypeProvider : StringPropertyProvider
    {
        public override float Order => 21.1f;
        public override string Key => Parameters.CONNECTION_TYPE;
        public override string Provide() => null;
    }
}