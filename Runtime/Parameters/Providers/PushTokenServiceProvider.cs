using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Usecase;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.PUSHTOKEN_SERVICE]
     */
    internal class PushTokenServiceProvider : StringPropertyProvider
    {
        private readonly IPushTokenUseCase _useCase;

        public PushTokenServiceProvider(IPushTokenUseCase useCase)
        {
            _useCase = useCase;
        }

        public override float Order => 65.1f;
        public override ProviderType? Key => ProviderType.PUSHTOKEN_SERVICE;

        public override string Provide() => _useCase.GetPushTokenService();
    }
}