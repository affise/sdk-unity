using AffiseAttributionLib.AffiseParameters.Base;
using UnityEngine;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.USER_AGENT]
     */
    public class UserAgentProvider : StringPropertyProvider
    {
        public override float Order => 35.0f;
        public override string Key => Parameters.USER_AGENT;
        public override string Provide()
        {
            return $"UnityPlayer/{Application.unityVersion} (UnityWebRequest/1.0, libcurl)";
        }
    }
}