using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Extensions;
using UnityEngine;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    
    /**
     * Provider for parameter [ProviderType.SDK_PLATFORM]
     */
    internal class SdkPlatformNameProvider : StringPropertyProvider
    {
        private const string UNITY = "unity";
        public override float Order => 45.0f;
        public override ProviderType? Key => ProviderType.SDK_PLATFORM;
        public override string Provide()
        {
            return $"{UNITY} {Application.platform.ToValue()}";
        }
    }
}