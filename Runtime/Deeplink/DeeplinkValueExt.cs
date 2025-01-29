#nullable enable
using System;
using System.Collections.Generic;

namespace AffiseAttributionLib.Deeplink
{
    internal static class DeeplinkValueExt
    {
        public static DeeplinkValue ToDeeplinkValue(this Uri uri)
        {
            var query = System.Web.HttpUtility.ParseQueryString(uri.Query);
            var parameters = new Dictionary<string, List<string>>();
            
            foreach (var key in query.AllKeys)
            {
                parameters[key] = new List<string>(query.GetValues(key) ?? Array.Empty<string>());
            }
            
            return new DeeplinkValue(
                deeplink: uri.AbsolutePath,
                scheme: uri.Scheme,
                host: uri.Host,
                path: uri.LocalPath,
                parameters: parameters
            );
        }
    }
}