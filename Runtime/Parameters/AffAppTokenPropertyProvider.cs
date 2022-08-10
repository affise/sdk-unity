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

        public override string ProvideWithParam(string param) => _stringToSHA256Converter.Convert(
            _initProperties.GetProperties().affiseAppId +
            param +
            _initProperties.GetProperties().secretId
        );
    }
}