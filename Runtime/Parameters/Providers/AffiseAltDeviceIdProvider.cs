using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Usecase;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.AFFISE_ALT_DEVICE_ID]
     */
    internal class AffiseAltDeviceIdProvider : StringPropertyProvider
    {   
        public override float Order => 27.0f;
        public override ProviderType? Key => ProviderType.AFFISE_ALT_DEVICE_ID;
        
        private readonly FirstAppOpenUseCase _useCase;

        public AffiseAltDeviceIdProvider(FirstAppOpenUseCase firstAppOpenUseCase)
        {
            _useCase = firstAppOpenUseCase;
        }

        public override string Provide() => _useCase.GetAffiseAltDeviseId();
    }
}