using AffiseAttributionLib.AffiseParameters.Base;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.REFERRER_CLICK_TIME_SERVER]
     */
    internal class ReferrerClickTimestampServerProvider : LongPropertyProvider
    {
        public override float Order => 16.0f;
        public override string Key => Parameters.REFERRER_CLICK_TIME_SERVER;
        public override long? Provide() => null;
    }
}