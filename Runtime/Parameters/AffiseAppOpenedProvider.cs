using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Session;

namespace AffiseAttributionLib.AffiseParameters
{
    internal class AffiseAppOpenedProvider : LongPropertyProvider
    {
        private readonly ISessionManager _sessionManager;

        public AffiseAppOpenedProvider(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        public override long? Provide() => _sessionManager.GetSessionStartTime();
    }
}