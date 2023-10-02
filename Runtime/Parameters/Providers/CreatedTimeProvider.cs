using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Utils;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.CREATED_TIME]
     */
    internal class CreatedTimeProvider : LongPropertyProvider
    {
        public override float Order => 18.0f;
        public override ProviderType? Key => ProviderType.CREATED_TIME;
        public override long? Provide() => Timestamp.New();
    }
}