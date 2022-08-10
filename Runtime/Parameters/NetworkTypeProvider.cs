using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Native;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.NETWORK_TYPE]
     */
    internal class NetworkTypeProvider : StringPropertyProvider
    {
        private readonly INativeUseCase _useCase;

        public NetworkTypeProvider(INativeUseCase useCase)
        {
            _useCase = useCase;
        }

        public override string Provide() => _useCase.GetNetworkType();
    }
}