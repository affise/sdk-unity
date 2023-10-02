using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Deeplink;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.DEEPLINK_CLICK]
     */
    internal class DeeplinkClickPropertyProvider : BooleanPropertyProvider
    {
        public override float Order => 25.0f;
        public override ProviderType? Key => ProviderType.DEEPLINK_CLICK;
        private readonly IDeeplinkClickRepository _deeplinkClickRepository;

        public DeeplinkClickPropertyProvider(IDeeplinkClickRepository deeplinkClickRepository)
        {
            _deeplinkClickRepository = deeplinkClickRepository;
        }

        public override bool? Provide() => _deeplinkClickRepository.IsDeeplinkClick();
    }
}