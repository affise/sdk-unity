using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Init;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.AFFISE_PART_PARAM_NAME]
     */
    internal class AffPartParamNamePropertyProvider : StringPropertyProvider
    {
        private readonly IInitPropertiesStorage _initProperties;

        public AffPartParamNamePropertyProvider(IInitPropertiesStorage initProperties)
        {
            _initProperties = initProperties;
        }

        public override string Provide() => _initProperties.GetProperties().partParamName;
    }
}