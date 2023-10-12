#nullable enable
namespace AffiseAttributionLib.Network
{
    public class HttpResponse
    {
        public long Code { get; }
        public string Message { get; }
        public string? Body { get; }

        public HttpResponse(long code, string message, string? body)
        {
            Code = code;
            Message = message;
            Body = body;
        }

        public override string ToString()
        {
            return $"HttpResponse(code={Code}, message={Message}, body={Body ?? ""})";
        }
    }
}