using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Extensions;
using UnityEngine.Device;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.PLATFORM]
     */
    internal class PlatformNameProvider : StringPropertyProvider
    {
        public override float Order => 45.0f;
        public override ProviderType? Key => ProviderType.PLATFORM;
        public override string Provide() => Application.platform.ToValue();
    }
}