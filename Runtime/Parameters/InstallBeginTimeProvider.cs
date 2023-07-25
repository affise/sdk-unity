using AffiseAttributionLib.AffiseParameters.Base;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.INSTALL_BEGIN_TIME]
     */
    internal class InstallBeginTimeProvider : LongPropertyProvider
    {
        public override float Order => 11.0f;
        public override string Key => Parameters.INSTALL_BEGIN_TIME;
        public override long? Provide() => null;
    }
}