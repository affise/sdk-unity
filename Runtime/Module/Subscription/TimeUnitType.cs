#nullable enable

using System;

namespace AffiseAttributionLib.Module.Subscription
{
    public enum TimeUnitType
    {
        DAY,
        WEEK,
        MONTH,
        YEAR,
    }    
    
    public static class TimeUnitTypeExt
    {
        public static string? ToValue(this TimeUnitType param)
        {
            return param switch
            {
                TimeUnitType.DAY => "day",
                TimeUnitType.WEEK => "week",
                TimeUnitType.MONTH => "month",
                TimeUnitType.YEAR => "year",
                _ => null
            };
        } 
        
        internal static TimeUnitType? From(string? value)
        {
            if (value is null) return null;
            foreach (var type in Enum.GetValues(typeof(TimeUnitType)))
            {
                if (type is not TimeUnitType unitType) continue;
                if (unitType.ToValue() == value) return unitType;
            }
            return null;
        }
    }
}