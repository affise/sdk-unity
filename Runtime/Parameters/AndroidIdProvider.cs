using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Native;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.ANDROID_ID]
     */
    internal class AndroidIdProvider : StringPropertyProvider
    {
        private readonly INativeUseCase _useCase;

        public AndroidIdProvider(INativeUseCase useCase)
        {
            _useCase = useCase;
        }

        public override string Provide() => _useCase.GetAndroidId();
    }
}