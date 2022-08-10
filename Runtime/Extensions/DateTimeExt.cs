using System;

namespace AffiseAttributionLib.Extensions
{
    public static class DateTimeExt
    {
        public static long GetTimeInMillis(this DateTime date)
        {
            return ((DateTimeOffset)date).ToUnixTimeMilliseconds();
        }
    }
}