﻿using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Usecase;
using AffiseAttributionLib.Utils;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.INSTALL_FINISH_TIME]
     */
    internal class InstallFinishTimeProvider : LongPropertyProvider
    {
        public override float Order => 12.0f;
        public override string Key => Parameters.INSTALL_FINISH_TIME;
        
        private readonly FirstAppOpenUseCase _useCase;

        public InstallFinishTimeProvider(FirstAppOpenUseCase firstAppOpenUseCase)
        {
            _useCase = firstAppOpenUseCase;
        }

        public override long? Provide() => _useCase.GetFirstOpenDate()?.GetTimeInMillis();
    }
}