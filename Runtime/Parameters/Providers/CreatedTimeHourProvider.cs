using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Utils;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.CREATED_TIME_HOUR]
     */
    internal class CreatedTimeHourProvider : LongPropertyProvider
    {
        public override float Order => 20.0f;
        public override ProviderType? Key => ProviderType.CREATED_TIME_HOUR;
        public override long? Provide() => Timestamp.NewHour();
    }
}