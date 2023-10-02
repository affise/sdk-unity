using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Session;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.LIFETIME_SESSION_COUNT]
     */
    internal class LifetimeSessionCountProvider : LongPropertyProvider
    {
        public override float Order => 57.0f;
        public override ProviderType? Key => ProviderType.LIFETIME_SESSION_COUNT;
        
        private readonly ISessionManager _sessionManager;

        public LifetimeSessionCountProvider(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        public override long? Provide()
        {
            return _sessionManager.GetLifetimeSessionTime();
        }
    }
}