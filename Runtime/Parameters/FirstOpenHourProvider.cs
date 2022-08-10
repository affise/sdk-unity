using System;
using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Extensions;
using AffiseAttributionLib.Usecase;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.FIRST_OPEN_HOUR]
     */
    internal class FirstOpenHourProvider : LongPropertyProvider
    {
        private readonly FirstAppOpenUseCase _useCase;

        public FirstOpenHourProvider(FirstAppOpenUseCase firstAppOpenUseCase)
        {
            _useCase = firstAppOpenUseCase;
        }
        
        public override long? Provide()
        {
            var date = _useCase.GetFirstOpenDate();
            var result = new DateTime(date.Year, date.Month, date.Day, date.Hour, 0, 0);
            return result.ToLocalTime().GetTimeInMillis();
        }
    }
}