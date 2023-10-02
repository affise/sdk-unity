using AffiseAttributionLib.AffiseParameters.Base;
using UnityEngine;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.USER_AGENT]
     */
    public class UserAgentProvider : StringPropertyProvider
    {
        public override float Order => 35.0f;
        public override ProviderType? Key => ProviderType.USER_AGENT;
        public override string Provide()
        {
            return $"UnityPlayer/{Application.unityVersion} (UnityWebRequest/1.0, libcurl)";
        }
    }
}