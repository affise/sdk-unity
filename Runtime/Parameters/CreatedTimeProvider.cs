using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Utils;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.CREATED_TIME]
     */
    internal class CreatedTimeProvider : LongPropertyProvider
    {
        public override float Order => 18.0f;
        public override string Key => Parameters.CREATED_TIME;
        public override long? Provide() => Timestamp.New();
    }
}