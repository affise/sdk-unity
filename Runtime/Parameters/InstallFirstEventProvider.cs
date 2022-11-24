using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Usecase;

namespace AffiseAttributionLib.AffiseParameters
{
    
    /**
     * Provider for parameter [Parameters.INSTALL_FIRST_EVENT]
     */
    internal class InstallFirstEventProvider : BooleanPropertyProvider
    {
        private readonly FirstAppOpenUseCase _useCase;

        public InstallFirstEventProvider(FirstAppOpenUseCase useCase)
        {
            _useCase = useCase;
        }

        public override bool? Provide() => _useCase.IsFirstOpen();
    }
}