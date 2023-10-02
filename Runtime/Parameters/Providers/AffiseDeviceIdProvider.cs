using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Usecase;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.AFFISE_DEVICE_ID]
     */
    internal class AffiseDeviceIdProvider : StringPropertyProvider
    {
        public override float Order => 27.0f;
        public override ProviderType? Key => ProviderType.AFFISE_DEVICE_ID;
        
        private readonly FirstAppOpenUseCase _useCase;

        public AffiseDeviceIdProvider(FirstAppOpenUseCase firstAppOpenUseCase)
        {
            _useCase = firstAppOpenUseCase;
        }

        public override string Provide() => _useCase.GetAffiseDeviseId();
    }
}