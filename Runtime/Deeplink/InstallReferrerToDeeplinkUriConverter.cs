#nullable enable
using System;
using System.Web;
using AffiseAttributionLib.Converter;

namespace AffiseAttributionLib.Deeplink
{
    public class InstallReferrerToDeeplinkUriConverter: IConverter<string, Uri?>
    {
        private const string DEEPLINK_PARAM_NAME = "deeplink";
            
        public Uri? Convert(string from)
        {
            var uri = new Uri(from);
            return ExtractDeeplinkFromAbsolute(uri) ?? ExtractDeeplinkFromRelativeFrom(from);
        }

     
        private Uri? ExtractDeeplinkFromRelativeFrom(string from)
        {
            var builder = new UriBuilder(HttpUtility.UrlEncode(from));
            return ExtractDeeplinkFromAbsolute(builder.Uri);
        }

        private Uri? ExtractDeeplinkFromAbsolute(Uri from)
        {
            var param = HttpUtility.ParseQueryString(from.Query).Get(DEEPLINK_PARAM_NAME);
            return new Uri(param);
        }
    }
}