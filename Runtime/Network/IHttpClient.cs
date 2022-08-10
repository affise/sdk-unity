using System;
using System.Collections.Generic;
using AffiseAttributionLib.Network.Response;

namespace AffiseAttributionLib.Network
{
    public interface IHttpClient
    {
        public enum Method
        {
            Get,
            Post
        }

        System.Collections.IEnumerator ExecuteRequest(
            string httpsUrl,
            Method method,
            string data,
            Dictionary<string, string> headers,
            Action<string> onSuccess = null,
            Action<ErrorResponse> onError = null
        );
    }
}