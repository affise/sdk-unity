#nullable enable
using System;
using System.Collections.Generic;
using AffiseAttributionLib.Debugger.Validate;
using AffiseAttributionLib.Extensions;
using AffiseAttributionLib.Network;
using SimpleJSON;

namespace AffiseAttributionLib.Native.Utils
{
    internal static class DebugUtils
    {
        private const string REQUEST = "request";
        private const string RESPONSE = "response";
        private const string METHOD = "method";
        private const string URL = "url";
        private const string HEADERS = "headers";
        private const string BODY = "body";
        private const string CODE = "code";
        private const string MESSAGE = "message";

        public static HttpRequest ParseRequest(JSONNode? node)
        {
            var json = node?.AsObject;
            
            var reqUrl = json?[URL]?.Value ?? "";
            var reqMethod = json?[METHOD]?.Value.ToHttpClientMethod() ?? IHttpClient.Method.POST;
            var reqBody = json?[BODY]?.ToString();
            var reqHeaders = json?[HEADERS]?.AsObject?.ToMapOfStrings() ?? new Dictionary<string, string>();

            return new HttpRequest(reqUrl, reqMethod, reqHeaders, reqBody);
        }

        public static HttpResponse ParseResponse(JSONNode? node)
        {
            var json = node?.AsObject;
            
            var resCode = json?[CODE]?.AsLong ?? 0L;
            var resMessage = json?[MESSAGE]?.Value ?? "";
            var resBody = json?[BODY]?.ToString();

            return new HttpResponse(resCode, resMessage, resBody);
        }

        public static Tuple<HttpRequest, HttpResponse> ParseRequestResponse(JSONNode? node)
        {
            var json = node?.AsObject;
            return new Tuple<HttpRequest, HttpResponse>(
                ParseRequest(json?[REQUEST]),
                ParseResponse(json?[RESPONSE])
            );
        }

        public static ValidationStatus GetValidationStatus(string? value)
        {
            return value.ToValidationStatus() ?? ValidationStatus.UNKNOWN_ERROR;
        }
    }
}