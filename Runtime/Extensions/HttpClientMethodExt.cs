#nullable enable
using System;
using AffiseAttributionLib.Network;

namespace AffiseAttributionLib.Extensions
{
    internal static class HttpClientMethodExt
    {
        public static IHttpClient.Method? ToHttpClientMethod(this string? value)
        {
            if (value is null) return null;
            foreach (var type in Enum.GetValues(typeof(IHttpClient.Method)))
            {
                if (type is not IHttpClient.Method method) continue;
                if (method.ToString() == value) return method;
            }
            return null;
        }
    }
}