using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Init;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.AFFISE_PART_PARAM_NAME]
     */
    internal class AffPartParamNamePropertyProvider : StringPropertyProvider
    {
        public override float Order => 59.0f;
        public override ProviderType? Key => ProviderType.AFFISE_PART_PARAM_NAME;
        private readonly IInitPropertiesStorage _initProperties;

        public AffPartParamNamePropertyProvider(IInitPropertiesStorage initProperties)
        {
            _initProperties = initProperties;
        }

        public override string Provide() => _initProperties.GetProperties().PartParamName;
    }
}