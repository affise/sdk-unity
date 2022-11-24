using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Deeplink;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for property [Parameters.DEEPLINK_CLICK]
     */
    internal class DeeplinkClickPropertyProvider : BooleanPropertyProvider
    {
        private readonly IDeeplinkClickRepository _deeplinkClickRepository;

        public DeeplinkClickPropertyProvider(IDeeplinkClickRepository deeplinkClickRepository)
        {
            _deeplinkClickRepository = deeplinkClickRepository;
        }

        public override bool? Provide() => _deeplinkClickRepository.IsDeeplinkClick();
    }
}