using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Native;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.STORE]
     */
    internal class StoreProvider : StringPropertyProvider
    {
        private readonly INativeUseCase _useCase;

        public StoreProvider(INativeUseCase useCase)
        {
            _useCase = useCase;
        }

        public override string Provide() => _useCase.GetStore();
    }
}