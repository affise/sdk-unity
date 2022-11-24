using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Native;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.REFERRER_CLICK_TIME]
     */
    internal class ReferrerClickTimestampProvider : LongPropertyProvider
    {
        private readonly INativeUseCase _useCase;

        public ReferrerClickTimestampProvider(INativeUseCase useCase)
        {
            _useCase = useCase;
        }

        public override long? Provide() => _useCase.GetReferrerClickTimestamp();
    }
}