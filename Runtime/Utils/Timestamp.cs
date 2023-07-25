using System;

namespace AffiseAttributionLib.Utils
{
    public static class Timestamp
    {
        public static long New()
        {
            return DateTime.UtcNow.GetTimeInMillis();
        }
        
        public static long NewHour()
        {
            return DateTime.UtcNow.TimestampHour();
        }

        public static long ForHour(this long timestamp)
        {
            var date = DateTimeOffset.FromUnixTimeMilliseconds(timestamp).DateTime;
            var result = new DateTime(date.Year, date.Month, date.Day, date.Hour, 0, 0);
            return result.GetTimestamp();
        }
        
        public static long GetTimeInMillis(this DateTime date)
        {
            return ((DateTimeOffset)date).ToUnixTimeMilliseconds();
        }
        
        public static long TimestampHour(this DateTime date)
        {
            var result = new DateTime(date.Year, date.Month, date.Day, date.Hour, 0, 0);
            return result.GetTimestamp();
        }
        
        public static long GetTimestamp(this DateTime date)
        {
            return date.ToLocalTime().GetTimeInMillis();
        }
    }
}