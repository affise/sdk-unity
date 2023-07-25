using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Session;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.LIFETIME_SESSION_COUNT]
     */
    internal class LifetimeSessionCountProvider : LongPropertyProvider
    {
        public override float Order => 57.0f;
        public override string Key => Parameters.LIFETIME_SESSION_COUNT;
        
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