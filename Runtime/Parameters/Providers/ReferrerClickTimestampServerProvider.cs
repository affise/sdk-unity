using AffiseAttributionLib.AffiseParameters.Base;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.REFERRER_CLICK_TIME_SERVER]
     */
    internal class ReferrerClickTimestampServerProvider : LongPropertyProvider
    {
        public override float Order => 16.0f;
        public override ProviderType? Key => ProviderType.REFERRER_CLICK_TIME_SERVER;
        public override long? Provide() => null;
    }
}