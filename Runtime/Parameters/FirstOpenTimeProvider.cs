using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Usecase;
using AffiseAttributionLib.Utils;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.FIRST_OPEN_TIME]
     */
    internal class FirstOpenTimeProvider : LongPropertyProvider
    {
        public override float Order => 7.0f;
        public override string Key => Parameters.FIRST_OPEN_TIME;
        
        private readonly FirstAppOpenUseCase _useCase;

        public FirstOpenTimeProvider(FirstAppOpenUseCase firstAppOpenUseCase)
        {
            _useCase = firstAppOpenUseCase;
        }

        public override long? Provide() => _useCase.GetFirstOpenDate()?.GetTimeInMillis();
    }
}