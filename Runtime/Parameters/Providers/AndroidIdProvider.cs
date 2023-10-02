using AffiseAttributionLib.AffiseParameters.Base;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.ANDROID_ID]
     */
    internal class AndroidIdProvider : StringPropertyProvider
    {
        public override float Order => 30.0f;
        public override ProviderType? Key => ProviderType.ANDROID_ID;
        
        public override string Provide() => null;
    }
}