using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Utils;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.PUSHTOKEN]
     */
    internal class PushTokenProvider : StringPropertyProvider
    {
        public override float Order => 65.0f;
        public override ProviderType? Key => ProviderType.PUSHTOKEN;
        public const string KEY_APP_PUSHTOKEN = "com.affise.attribution.init.PUSHTOKEN";
        
        public override string Provide()
        {
            return PrefUtils.GetString(KEY_APP_PUSHTOKEN, null);
        }
    }
}