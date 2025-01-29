#nullable enable
using System;
using System.Web;
using AffiseAttributionLib.Referrer;

namespace AffiseAttributionLib.Utils
{
    internal static class Referrer
    {
        public static string? GetReferrerValue(this string? url, ReferrerKey key)
        {
            if (url is null) return null;
            try
            {
                return HttpUtility.ParseQueryString(url)
                    .Get(key.ToValue());
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}