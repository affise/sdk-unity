using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Usecase;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.AFFISE_ALT_DEVICE_ID]
     */
    internal class AffiseAltDeviceIdProvider : StringPropertyProvider
    {
        private readonly FirstAppOpenUseCase _useCase;

        public AffiseAltDeviceIdProvider(FirstAppOpenUseCase firstAppOpenUseCase)
        {
            _useCase = firstAppOpenUseCase;
        }

        public override string Provide() => _useCase.GetAffiseAltDeviseId();
    }
}