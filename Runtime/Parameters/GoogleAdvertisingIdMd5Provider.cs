using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Converter;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.GAID_ADID_MD5]
     */
    internal class GoogleAdvertisingIdMd5Provider : StringPropertyProvider
    {
        public override float Order => 31.4f;
        public override string Key => Parameters.GAID_ADID_MD5;
        
        private readonly IConverter<string, string> _md5Converter;

        public GoogleAdvertisingIdMd5Provider(IConverter<string, string> md5Converter)
        {
            _md5Converter = md5Converter;
        }

        public override string Provide()
        {
            var gaidAdid = "";

            if (string.IsNullOrEmpty(gaidAdid)) return "";

            return _md5Converter.Convert(gaidAdid);
        }
    }
}