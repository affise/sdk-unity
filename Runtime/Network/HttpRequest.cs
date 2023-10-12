#nullable enable
using System.Collections.Generic;
using System.Linq;

namespace AffiseAttributionLib.Network
{
    public class HttpRequest
    {
        public string Url { get; }
        public IHttpClient.Method Method { get; }
        public Dictionary<string, string> Headers { get; }
        public string? Body { get; }

        public HttpRequest(string url, IHttpClient.Method method, Dictionary<string, string> headers, string? body)
        {
            Url = url;
            Method = method;
            Headers = headers;
            Body = body;
        }

        public override string ToString()
        {
            var arrayHeaders = Headers.Select(h => $"{h.Key}={h.Value}").ToList();
            var headers = string.Join("; ", arrayHeaders);
            return $"HttpRequest(url={Url}, method={Method}, headers={{{headers}}}, body={Body ?? ""})";
        }
    }
}