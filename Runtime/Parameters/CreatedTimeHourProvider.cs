using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Utils;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.CREATED_TIME_HOUR]
     */
    internal class CreatedTimeHourProvider : LongPropertyProvider
    {
        public override float Order => 20.0f;
        public override string Key => Parameters.CREATED_TIME_HOUR;
        public override long? Provide() => Timestamp.NewHour();
    }
}