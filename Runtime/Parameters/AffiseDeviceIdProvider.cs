using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Usecase;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.AFFISE_DEVICE_ID]
     */
    internal class AffiseDeviceIdProvider : StringPropertyProvider
    {
        private readonly FirstAppOpenUseCase _useCase;

        public AffiseDeviceIdProvider(FirstAppOpenUseCase firstAppOpenUseCase)
        {
            _useCase = firstAppOpenUseCase;
        }

        public override string Provide() => _useCase.GetAffiseDeviseId();
    }
}