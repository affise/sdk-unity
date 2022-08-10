using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Session;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.LIFETIME_SESSION_COUNT]
     */
    internal class LifetimeSessionCountProvider : LongPropertyProvider
    {
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