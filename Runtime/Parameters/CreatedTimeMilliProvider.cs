using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Utils;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.CREATED_TIME_MILLI]
     */
    internal class CreatedTimeMilliProvider : LongPropertyProvider
    {
        public override float Order => 19.0f;
        public override string Key => Parameters.CREATED_TIME_MILLI;
        public override long? Provide() => Timestamp.New();
    }
}