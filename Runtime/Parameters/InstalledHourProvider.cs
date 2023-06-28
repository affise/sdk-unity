using System;
using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Extensions;
using AffiseAttributionLib.Native.NativeUseCase;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.INSTALLED_HOUR]
     */
    internal class InstalledHourProvider : LongPropertyProvider
    {
        private readonly INativeUseCase _useCase;

        public InstalledHourProvider(INativeUseCase useCase)
        {
            _useCase = useCase;
        }

        public override long? Provide()
        {
            var timestamp = _useCase.GetInstalledTime();
            if (timestamp is null) return null;
            
            var date = DateTimeOffset.FromUnixTimeMilliseconds(timestamp ?? 0).DateTime;
            var result = new DateTime(date.Year, date.Month, date.Day, date.Hour, 0, 0);
            return result.ToLocalTime().GetTimeInMillis();
        }
    }
}