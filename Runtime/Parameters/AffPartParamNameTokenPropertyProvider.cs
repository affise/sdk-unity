using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Init;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.AFFISE_PART_PARAM_NAME_TOKEN]
     */
    internal class AffPartParamNameTokenPropertyProvider : StringPropertyProvider
    {
        private readonly IInitPropertiesStorage _initProperties;

        public AffPartParamNameTokenPropertyProvider(IInitPropertiesStorage initProperties)
        {
            _initProperties = initProperties;
        }

        public override string Provide() => _initProperties.GetProperties().partParamNameToken;
    }
}