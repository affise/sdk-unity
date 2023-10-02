using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Init;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.AFFISE_APP_ID]
     */
    internal class AffiseAppIdProvider : StringPropertyProvider
    {
        public override float Order => 1.0f;
        public override ProviderType? Key => ProviderType.AFFISE_APP_ID;
        
        private readonly IInitPropertiesStorage _initProperties;

        public AffiseAppIdProvider(IInitPropertiesStorage initProperties)
        {
            _initProperties = initProperties;
        }

        public override string Provide() => _initProperties.GetProperties().AffiseAppId;
    }
}