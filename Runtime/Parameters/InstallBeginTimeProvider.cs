using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Native;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.INSTALL_BEGIN_TIME]
     */
    internal class InstallBeginTimeProvider : LongPropertyProvider
    {
        private readonly INativeUseCase _useCase;

        public InstallBeginTimeProvider(INativeUseCase useCase)
        {
            _useCase = useCase;
        }

        public override long? Provide() => _useCase.GetInstalledBeginTime();
    }
}