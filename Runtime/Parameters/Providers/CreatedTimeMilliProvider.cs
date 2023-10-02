using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Utils;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.CREATED_TIME_MILLI]
     */
    internal class CreatedTimeMilliProvider : LongPropertyProvider
    {
        public override float Order => 19.0f;
        public override ProviderType? Key => ProviderType.CREATED_TIME_MILLI;
        public override long? Provide() => Timestamp.New();
    }
}