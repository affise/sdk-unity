using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Native.NativeUseCase;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provides connection type [Parameters.CONNECTION_TYPE]
     */
    internal class ConnectionTypeProvider : StringPropertyProvider
    {
        private readonly INativeUseCase _useCase;

        public ConnectionTypeProvider(INativeUseCase useCase)
        {
            _useCase = useCase;
        }

        public override string Provide() => _useCase.GetConnectionType();
    }
}