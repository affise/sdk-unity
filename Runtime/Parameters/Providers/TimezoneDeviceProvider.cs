using System;
using AffiseAttributionLib.AffiseParameters.Base;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.TIMEZONE_DEV]
     */
    internal class TimezoneDeviceProvider : StringPropertyProvider
    {
        public override float Order => 51.0f;
        public override ProviderType? Key => ProviderType.TIMEZONE_DEV;
        public override string Provide() => GetOffset();

        private string GetOffset()
        {
            var timeSpan = TimeZoneInfo.Local.BaseUtcOffset;
            var sign = (timeSpan < TimeSpan.Zero) ? "-" : "+";
            return $"UTC{sign}{timeSpan:hhmm}";
        }
    }
}