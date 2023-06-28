using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Native.NativeUseCase;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.REFERRER]
     */
    internal class InstallReferrerProvider : StringPropertyProvider
    {
        private readonly INativeUseCase _useCase;

        public InstallReferrerProvider(INativeUseCase useCase)
        {
            _useCase = useCase;
        }

        public override string Provide() => _useCase.GetReferrer();
    }
}