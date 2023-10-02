using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Utils;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.UUID]
     */
    internal class UuidProvider : StringPropertyProvider
    {
        public override float Order => 64.0f;
        public override ProviderType? Key => ProviderType.UUID;
        public override string Provide()
        {
            return Uuid.Generate();
        }
    }
}