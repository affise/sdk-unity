using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Native.NativeUseCase;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.REFERRER_GOOGLE_PLAY_INSTANT]
     */
    internal class ReferrerGooglePlayInstantProvider : BooleanPropertyProvider
    {
        private readonly INativeUseCase _useCase;

        public ReferrerGooglePlayInstantProvider(INativeUseCase useCase)
        {
            _useCase = useCase;
        }
        
        public override bool? Provide() => _useCase.GetReferrerGooglePlayInstant();
    }
}