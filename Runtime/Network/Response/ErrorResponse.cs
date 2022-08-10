namespace AffiseAttributionLib.Network.Response
{
    public class ErrorResponse
    {
        public string Message { get; }
        public long Status { get; }

        public ErrorResponse(string message, long status)
        {
            Message = message;
            Status = status;
        }
    }
}