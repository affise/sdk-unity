using AffiseAttributionLib.AffiseParameters.Base;
using UnityEngine;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.USER_AGENT]
     */
    internal class UserAgentProvider : StringPropertyProvider
    {
        public override string Provide()
        {
            return $"UnityPlayer/{Application.unityVersion} (UnityWebRequest/1.0, libcurl)";
        }
    }
}