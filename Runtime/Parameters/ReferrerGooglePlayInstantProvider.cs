using AffiseAttributionLib.AffiseParameters.Base;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.REFERRER_GOOGLE_PLAY_INSTANT]
     */
    internal class ReferrerGooglePlayInstantProvider : BooleanPropertyProvider
    {
        public override float Order => 17.0f;
        public override string Key => Parameters.REFERRER_GOOGLE_PLAY_INSTANT;
        public override bool? Provide() => null;
    }
}