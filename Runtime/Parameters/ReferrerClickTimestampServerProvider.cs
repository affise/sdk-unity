using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Native;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.REFERRER_CLICK_TIME_SERVER]
     */
    internal class ReferrerClickTimestampServerProvider : LongPropertyProvider
    {
        private readonly INativeUseCase _useCase;

        public ReferrerClickTimestampServerProvider(INativeUseCase useCase)
        {
            _useCase = useCase;
        }

        public override long? Provide() => _useCase.GetReferrerClickTimestampServer();
    }
}