using AffiseAttributionLib.AffiseParameters.Base;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.INSTALLED_TIME]
     */
    internal class InstalledTimeProvider : LongPropertyProvider
    {
        public override float Order => 6.0f;
        public override string Key => Parameters.INSTALLED_TIME;
        public override long? Provide() => null;
    }
}