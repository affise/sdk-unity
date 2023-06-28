using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Native.NativeUseCase;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.API_LEVEL_OS]
     */
    internal class ApiLevelOSProvider : StringPropertyProvider
    {
        private readonly INativeUseCase _useCase;

        public ApiLevelOSProvider(INativeUseCase useCase)
        {
            _useCase = useCase;
        }

        public override string Provide() => _useCase.GetApiVersion();
    }
}