using System;
using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Extensions;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.CREATED_TIME_HOUR]
     */
    internal class CreatedTimeHourProvider : LongPropertyProvider
    {
        /**
         * Provider for parameter [Parameters.CREATED_TIME_HOUR]
         */
        public override long? Provide()
        {
            var date = DateTime.UtcNow;
            var result = new DateTime(date.Year, date.Month, date.Day, date.Hour, 0, 0);
            return result.ToLocalTime().GetTimeInMillis();
        }
    }
}