using AffiseAttributionLib.AffiseParameters.Base;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.INSTALLED_HOUR]
     */
    internal class InstalledHourProvider : LongPropertyProvider
    {
        public override float Order => 8.0f;
        public override string Key => Parameters.INSTALLED_HOUR;
        public override long? Provide() => null;
    }
}