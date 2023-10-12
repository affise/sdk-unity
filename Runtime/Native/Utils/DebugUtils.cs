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

        public static Tuple<HttpRequest, HttpResponse> ParseRequestResponse(JSONObject? json)
        {
            if (json is null)
            {
                return new Tuple<HttpRequest, HttpResponse>(
                    new HttpRequest(
                        url: "",
                        method: IHttpClient.Method.POST,
                        headers: new Dictionary<string, string>(),
                        body: null
                    ),
                    new HttpResponse(
                        code: 0,
                        message: "",
                        body: null
                    )
                );
            }

            var req = json[REQUEST]?.AsObject;
            var reqUrl = req?[URL]?.Value ?? "";
            var reqMethod = req?[METHOD]?.Value.ToHttpClientMethod() ?? IHttpClient.Method.POST;
            var reqBody = req?[BODY]?.ToString();
            var reqHeaders = req?[HEADERS]?.AsObject?.ToMapOfStrings() ?? new Dictionary<string, string>();

            var res = json[RESPONSE]?.AsObject;
            var resCode = res?[CODE]?.AsLong ?? 0L;
            var resMessage = res?[MESSAGE]?.Value ?? "";
            var resBody = res?[BODY]?.ToString();

            return new Tuple<HttpRequest, HttpResponse>(
                new HttpRequest(reqUrl, reqMethod, reqHeaders, reqBody),
                new HttpResponse(resCode, resMessage, resBody)
            );
        }

        public static ValidationStatus GetValidationStatus(string? value)
        {
            return value.ToValidationStatus() ?? ValidationStatus.UNKNOWN_ERROR;
        }
    }
}