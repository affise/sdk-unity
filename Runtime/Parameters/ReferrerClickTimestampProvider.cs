using AffiseAttributionLib.AffiseParameters.Base;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.REFERRER_CLICK_TIME]
     */
    internal class ReferrerClickTimestampProvider : LongPropertyProvider
    {
        public override float Order => 15.0f;
        public override string Key => Parameters.REFERRER_CLICK_TIME;
        public override long? Provide() => null;
    }
}