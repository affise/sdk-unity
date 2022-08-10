using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Native;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.GAID_ADID]
     */
    internal class GoogleAdvertisingIdProvider : StringPropertyProvider
    {
        private readonly INativeUseCase _useCase;

        public GoogleAdvertisingIdProvider(INativeUseCase useCase)
        {
            _useCase = useCase;
        }

        public override string Provide() => _useCase.GetGaidAdid();
    }
}