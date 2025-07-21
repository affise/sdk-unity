using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Usecase;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.PUSHTOKEN]
     */
    internal class PushTokenProvider : StringPropertyProvider
    {
        private readonly IPushTokenUseCase _useCase;

        public PushTokenProvider(IPushTokenUseCase useCase)
        {
            _useCase = useCase;
        }

        public override float Order => 65.0f;
        public override ProviderType? Key => ProviderType.PUSHTOKEN;

        public override string Provide() => _useCase.GetPushToken();
    }
}