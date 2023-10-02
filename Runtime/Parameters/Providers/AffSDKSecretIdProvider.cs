using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Init;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.AFFISE_SDK_SECRET_ID]
     */
    internal class AffSDKSecretIdProvider : StringPropertyProvider
    {
        public override float Order => 63.0f;
        public override ProviderType? Key => ProviderType.AFFISE_SDK_SECRET_ID;
        
        private readonly IInitPropertiesStorage _initProperties;

        public AffSDKSecretIdProvider(IInitPropertiesStorage initProperties)
        {
            _initProperties = initProperties;
        }

        public override string Provide() => _initProperties.GetProperties().SecretKey;
    }
}