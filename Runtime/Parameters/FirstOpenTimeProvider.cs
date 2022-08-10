using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Extensions;
using AffiseAttributionLib.Usecase;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.FIRST_OPEN_TIME]
     */
    internal class FirstOpenTimeProvider : LongPropertyProvider
    {
        private readonly FirstAppOpenUseCase _useCase;

        public FirstOpenTimeProvider(FirstAppOpenUseCase firstAppOpenUseCase)
        {
            _useCase = firstAppOpenUseCase;
        }

        public override long? Provide() => _useCase.GetFirstOpenDate().GetTimeInMillis();
    }
}