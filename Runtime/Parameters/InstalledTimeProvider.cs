using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Native;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.INSTALLED_TIME]
     */
    internal class InstalledTimeProvider : LongPropertyProvider
    {
        private readonly INativeUseCase _useCase;

        public InstalledTimeProvider(INativeUseCase useCase)
        {
            _useCase = useCase;
        }

        public override long? Provide() => _useCase.GetInstalledTime();
    }
}