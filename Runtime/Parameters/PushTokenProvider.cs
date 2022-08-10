using AffiseAttributionLib.AffiseParameters.Base;
using UnityEngine;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.PUSHTOKEN]
     */
    internal class PushTokenProvider : StringPropertyProvider
    {
        public const string KEY_APP_PUSHTOKEN = "com.affise.attribution.init.PUSHTOKEN";
        
        public override string Provide()
        {
            return PlayerPrefs.GetString(KEY_APP_PUSHTOKEN, null);
        }
    }
}