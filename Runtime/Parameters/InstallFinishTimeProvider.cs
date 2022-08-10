using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Extensions;
using AffiseAttributionLib.Usecase;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.INSTALL_FINISH_TIME]
     */
    internal class InstallFinishTimeProvider : LongPropertyProvider
    {
        private readonly FirstAppOpenUseCase _useCase;

        public InstallFinishTimeProvider(FirstAppOpenUseCase firstAppOpenUseCase)
        {
            _useCase = firstAppOpenUseCase;
        }

        public override long? Provide() => _useCase.GetFirstOpenDate().GetTimeInMillis();
    }
}