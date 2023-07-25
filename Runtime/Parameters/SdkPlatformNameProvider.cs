using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Extensions;
using UnityEngine;

namespace AffiseAttributionLib.AffiseParameters
{
    
    /**
     * Provider for parameter [Parameters.SDK_PLATFORM]
     */
    internal class SdkPlatformNameProvider : StringPropertyProvider
    {
        private const string UNITY = "unity";
        public override float Order => 45.0f;
        public override string Key => Parameters.SDK_PLATFORM;
        public override string Provide()
        {
            return $"{UNITY} {Application.platform.ToValue()}";
        }
    }
}