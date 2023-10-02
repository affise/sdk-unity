using AffiseAttributionLib.AffiseParameters.Base;
using UnityEngine.Device;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.OS_NAME]
     */
    internal class OsNameProvider : StringPropertyProvider
    {
        public override float Order => 43.0f;
        public override ProviderType? Key => ProviderType.OS_NAME;
        public override string Provide() => SystemInfo.operatingSystem;
    }
}