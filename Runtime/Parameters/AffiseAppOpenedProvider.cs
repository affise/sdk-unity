using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Session;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.AFFISE_APP_OPENED]
     */
    internal class AffiseAppOpenedProvider : LongPropertyProvider
    {
        public override float Order => 56.1f;
        public override string Key => Parameters.AFFISE_APP_OPENED;
        
        private readonly ISessionManager _sessionManager;

        public AffiseAppOpenedProvider(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        public override long? Provide() => _sessionManager.GetSessionStartTime();
    }
}