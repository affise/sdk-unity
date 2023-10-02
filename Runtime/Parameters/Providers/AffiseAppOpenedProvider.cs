using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Session;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.AFFISE_APP_OPENED]
     */
    internal class AffiseAppOpenedProvider : LongPropertyProvider
    {
        public override float Order => 56.1f;
        public override ProviderType? Key => ProviderType.AFFISE_APP_OPENED;
        
        private readonly ISessionManager _sessionManager;

        public AffiseAppOpenedProvider(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        public override long? Provide() => _sessionManager.GetSessionStartTime();
    }
}