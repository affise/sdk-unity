using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Native;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.REFERRER_INSTALL_VERSION]
     */
    internal class ReferrerInstallVersionProvider : StringPropertyProvider
    {
        private readonly INativeUseCase _useCase;

        public ReferrerInstallVersionProvider(INativeUseCase useCase)
        {
            _useCase = useCase;
        }

        public override string Provide() => _useCase.GetReferrerInstallVersion();
    }
}