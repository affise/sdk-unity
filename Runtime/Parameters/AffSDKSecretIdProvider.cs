using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Init;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.AFFISE_SDK_SECRET_ID]
     */
    internal class AffSDKSecretIdProvider : StringPropertyProvider
    {
        private readonly IInitPropertiesStorage _initProperties;

        public AffSDKSecretIdProvider(IInitPropertiesStorage initProperties)
        {
            _initProperties = initProperties;
        }

        public override string Provide() => _initProperties.GetProperties().secretId;
    }
}