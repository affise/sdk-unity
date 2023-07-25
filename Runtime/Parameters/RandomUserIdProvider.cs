using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Usecase;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.RANDOM_USER_ID]
     */
    internal class RandomUserIdProvider : StringPropertyProvider
    {
        public override float Order => 49.0f;
        public override string Key => Parameters.RANDOM_USER_ID;
        
        private readonly FirstAppOpenUseCase _firstAppOpenUseCase;

        public RandomUserIdProvider(FirstAppOpenUseCase firstAppOpenUseCase)
        {
            _firstAppOpenUseCase = firstAppOpenUseCase;
        }

        public override string Provide()
        {
            return _firstAppOpenUseCase.GetRandomUserId();
        }
    }
}