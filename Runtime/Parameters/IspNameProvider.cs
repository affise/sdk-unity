using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Native;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.ISP]
     */
    internal class IspNameProvider : StringPropertyProvider
    {
        private readonly INativeUseCase _useCase;

        public IspNameProvider(INativeUseCase useCase)
        {
            _useCase = useCase;
        }

        public override string Provide() => _useCase.GetIsp();
    }
}