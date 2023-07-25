using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Init;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.AFFISE_APP_ID]
     */
    internal class AffiseAppIdProvider : StringPropertyProvider
    {
        public override float Order => 1.0f;
        public override string Key => Parameters.AFFISE_APP_ID;
        
        private readonly IInitPropertiesStorage _initProperties;

        public AffiseAppIdProvider(IInitPropertiesStorage initProperties)
        {
            _initProperties = initProperties;
        }

        public override string Provide() => _initProperties.GetProperties().affiseAppId;
    }
}