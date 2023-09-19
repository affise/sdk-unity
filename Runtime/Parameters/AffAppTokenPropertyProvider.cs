using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Converter;
using AffiseAttributionLib.Init;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.AFFISE_APP_TOKEN]
     */
    internal class AffAppTokenPropertyProvider : StringWithParamPropertyProvider
    {
        public override float Order => 61.0f;
        public override string Key => Parameters.AFFISE_APP_TOKEN;
        
        private readonly IInitPropertiesStorage _initProperties;
        private readonly IConverter<string, string> _stringToSHA256Converter;

        public AffAppTokenPropertyProvider(
            IInitPropertiesStorage initProperties,
            IConverter<string, string> stringToSHA256Converter
        )
        {
            _initProperties = initProperties;
            _stringToSHA256Converter = stringToSHA256Converter;
        }

        protected override string ProvideWithParam(string param) => _stringToSHA256Converter.Convert(
            _initProperties.GetProperties().AffiseAppId +
            param +
            _initProperties.GetProperties().SecretKey
        );
    }
}