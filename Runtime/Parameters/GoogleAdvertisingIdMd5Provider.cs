using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Converter;
using AffiseAttributionLib.Native.NativeUseCase;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.GAID_ADID_MD5]
     */
    internal class GoogleAdvertisingIdMd5Provider : StringPropertyProvider
    {
        private readonly INativeUseCase _useCase;
        private readonly IConverter<string, string> _md5Converter;

        public GoogleAdvertisingIdMd5Provider(INativeUseCase useCase, IConverter<string, string> md5Converter)
        {
            _useCase = useCase;
            _md5Converter = md5Converter;
        }

        public override string Provide()
        {
            var gaidAdid = _useCase.GetGaidAdid();

            if (string.IsNullOrEmpty(gaidAdid)) return "";
                
            return _md5Converter.Convert(gaidAdid);
        }
    }
}