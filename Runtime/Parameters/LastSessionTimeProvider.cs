using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Session;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.LAST_SESSION_TIME]
     */
    internal class LastSessionTimeProvider : LongPropertyProvider
    {
        public override float Order => 21.0f;
        public override string Key => Parameters.LAST_SESSION_TIME;
        private readonly ISessionManager _sessionManager;

        public LastSessionTimeProvider(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        public override long? Provide()
        {
            return _sessionManager.GetLastInteractionTime();
        }
    }
}