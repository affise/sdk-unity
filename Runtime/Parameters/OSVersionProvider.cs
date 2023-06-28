using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Native.NativeUseCase;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.OS_VERSION]
     */
    internal class OSVersionProvider : StringPropertyProvider
    {
        private readonly INativeUseCase _useCase;

        public OSVersionProvider(INativeUseCase useCase)
        {
            _useCase = useCase;
        }

        public override string Provide() => _useCase.GetOSVersion();
    }
}