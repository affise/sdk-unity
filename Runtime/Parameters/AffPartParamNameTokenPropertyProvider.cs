using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Init;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.AFFISE_PART_PARAM_NAME_TOKEN]
     */
    internal class AffPartParamNameTokenPropertyProvider : StringPropertyProvider
    {
        public override float Order => 60.0f;
        public override string Key => Parameters.AFFISE_PART_PARAM_NAME_TOKEN;
        private readonly IInitPropertiesStorage _initProperties;

        public AffPartParamNameTokenPropertyProvider(IInitPropertiesStorage initProperties)
        {
            _initProperties = initProperties;
        }

        public override string Provide() => _initProperties.GetProperties().PartParamNameToken;
    }
}