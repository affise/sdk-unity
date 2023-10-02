using AffiseAttributionLib.AffiseParameters.Base;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.REFERRER_CLICK_TIME]
     */
    internal class ReferrerClickTimestampProvider : LongPropertyProvider
    {
        public override float Order => 15.0f;
        public override ProviderType? Key => ProviderType.REFERRER_CLICK_TIME;
        public override long? Provide() => null;
    }
}