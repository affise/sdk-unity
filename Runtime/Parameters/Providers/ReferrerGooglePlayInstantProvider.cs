using AffiseAttributionLib.AffiseParameters.Base;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.REFERRER_GOOGLE_PLAY_INSTANT]
     */
    internal class ReferrerGooglePlayInstantProvider : BooleanPropertyProvider
    {
        public override float Order => 17.0f;
        public override ProviderType? Key => ProviderType.REFERRER_GOOGLE_PLAY_INSTANT;
        public override bool? Provide() => null;
    }
}