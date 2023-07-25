﻿using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Usecase;
using AffiseAttributionLib.Utils;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.FIRST_OPEN_HOUR]
     */
    internal class FirstOpenHourProvider : LongPropertyProvider
    {
        public override float Order => 9.0f;
        public override string Key => Parameters.FIRST_OPEN_HOUR;
        
        private readonly FirstAppOpenUseCase _useCase;

        public FirstOpenHourProvider(FirstAppOpenUseCase firstAppOpenUseCase)
        {
            _useCase = firstAppOpenUseCase;
        }
        
        public override long? Provide() => _useCase.GetFirstOpenDate()?.TimestampHour();
    }
}