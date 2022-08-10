using System;
using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Extensions;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.CREATED_TIME_MILLI]
     */
    internal class CreatedTimeMilliProvider : LongPropertyProvider
    {
        public override long? Provide()
        {
            return DateTime.UtcNow.GetTimeInMillis();
        }
    }
}