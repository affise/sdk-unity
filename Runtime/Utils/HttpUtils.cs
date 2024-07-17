using System;
using System.Net;
using AffiseAttributionLib.Network;

namespace AffiseAttributionLib.Utils
{
    internal static class HttpUtils
    {
        private static readonly long Ok = Convert.ToInt64(HttpStatusCode.OK);
        private static readonly long BadRequest = Convert.ToInt64(HttpStatusCode.BadRequest);
        private static readonly long MultipleChoices = Convert.ToInt64(HttpStatusCode.MultipleChoices);

        private static bool IsHttpValid(long responseCode)
        {
            return  Ok <= responseCode && responseCode < BadRequest;
        }

        private static bool IsRedirect(long responseCode)
        {
            return  MultipleChoices <= responseCode && responseCode < BadRequest;
        }

        internal static bool IsValid(this HttpResponse response) => IsHttpValid(response.Code);
        internal static bool IsRedirect(this HttpResponse response) => IsRedirect(response.Code);
    }
}