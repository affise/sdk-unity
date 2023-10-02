using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Session;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.TIME_SESSION]
     */
    internal class TimeSessionProvider : LongPropertyProvider
    {
        public override float Order => 55.0f;
        public override ProviderType? Key => ProviderType.TIME_SESSION;
        private readonly ISessionManager _sessionManager;

        public TimeSessionProvider(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        public override long? Provide()
        {
            return _sessionManager.GetSessionTime();
        }
    }
}