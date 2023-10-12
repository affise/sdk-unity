using System;
using System.Net;

namespace AffiseAttributionLib.Utils
{
    internal static class HttpUtils
    {
        internal static readonly long Ok = Convert.ToInt64(HttpStatusCode.OK);
        internal static readonly long BadRequest = Convert.ToInt64(HttpStatusCode.BadRequest);
        internal static bool IsHttpValid(long responseCode)
        {
            return  Ok <= responseCode && responseCode < BadRequest;
        }
    }
}