using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Init;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.AFFISE_SDK_SECRET_ID]
     */
    internal class AffSDKSecretIdProvider : StringPropertyProvider
    {
        public override float Order => 63.0f;
        public override string Key => Parameters.AFFISE_SDK_SECRET_ID;
        
        private readonly IInitPropertiesStorage _initProperties;

        public AffSDKSecretIdProvider(IInitPropertiesStorage initProperties)
        {
            _initProperties = initProperties;
        }

        public override string Provide() => _initProperties.GetProperties().SecretKey;
    }
}