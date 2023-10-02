using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Usecase;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.RANDOM_USER_ID]
     */
    internal class RandomUserIdProvider : StringPropertyProvider
    {
        public override float Order => 49.0f;
        public override ProviderType? Key => ProviderType.RANDOM_USER_ID;
        
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