using System;

namespace AffiseAttributionLib.Exceptions
{
    public class NetworkException : Exception
    {
        public long Status { get; }

        public NetworkException(string message, long status) : base(message)
        {
            Status = status;
        }
    }
}