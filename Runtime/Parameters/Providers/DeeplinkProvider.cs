using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Deeplink;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.AFFISE_DEEPLINK]
     */
    internal class DeeplinkProvider : StringPropertyProvider
    {
        public override float Order => 58.0f;
        public override ProviderType? Key => ProviderType.AFFISE_DEEPLINK;
        
        private readonly IDeeplinkClickRepository _deeplinkClickRepository;

        public DeeplinkProvider(IDeeplinkClickRepository deeplinkClickRepository)
        {
            _deeplinkClickRepository = deeplinkClickRepository;
        }

        public override string Provide() => _deeplinkClickRepository.GetDeeplink();
    }
}