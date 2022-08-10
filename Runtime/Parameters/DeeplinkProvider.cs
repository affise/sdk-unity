using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Deeplink;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.AFFISE_DEEPLINK]
     */
    internal class DeeplinkProvider : StringPropertyProvider
    {
        private readonly IDeeplinkClickRepository _deeplinkClickRepository;

        public DeeplinkProvider(IDeeplinkClickRepository deeplinkClickRepository)
        {
            _deeplinkClickRepository = deeplinkClickRepository;
        }

        public override string Provide() => _deeplinkClickRepository.GetDeeplink();
    }
}