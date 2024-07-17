#nullable enable
using System.Collections.Generic;
using System.Linq;

namespace AffiseAttributionLib.Network
{
    public class HttpResponse
    {
        public long Code { get; }
        public string Message { get; }
        public string? Body { get; }

        public Dictionary<string, List<string>> Headers { get; } = new();

        public HttpResponse(long code, string message, string? body, Dictionary<string, List<string>> headers)
        {
            Code = code;
            Message = message;
            Body = body;
            Headers = headers;
        }

        public override string ToString()
        {
            var list = Headers.Select(h => $"{h.Key}=[{string.Join(", ", h.Value)}]").ToList();
            var headers = string.Join(", ", list);
            return $"HttpResponse(code={Code}, message={Message}, body={Body ?? ""}, headers=[{headers}])";
        }
    }
}