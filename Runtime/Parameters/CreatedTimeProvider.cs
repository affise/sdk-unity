using System;
using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Extensions;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.CREATED_TIME]
     */
    internal class CreatedTimeProvider : LongPropertyProvider
    {
        public override long? Provide()
        {
            var date = DateTime.UtcNow;
            var result = new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second);
            return result.ToLocalTime().GetTimeInMillis();
        }
    }
}