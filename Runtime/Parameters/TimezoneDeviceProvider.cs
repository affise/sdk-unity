using System;
using AffiseAttributionLib.AffiseParameters.Base;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.TIMEZONE_DEV]
     */
    internal class TimezoneDeviceProvider : StringPropertyProvider
    {
        public override float Order => 51.0f;
        public override string Key => Parameters.TIMEZONE_DEV;
        public override string Provide() => GetOffset();

        private string GetOffset()
        {
            var timeSpan = TimeZoneInfo.Local.BaseUtcOffset;
            var sign = (timeSpan < TimeSpan.Zero) ? "-" : "+";
            return $"UTC{sign}{timeSpan:hhmm}";
        }
    }
}