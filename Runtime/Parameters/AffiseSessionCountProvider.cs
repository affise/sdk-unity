﻿using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Session;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.AFFISE_SESSION_COUNT]
     */
    internal class AffiseSessionCountProvider : LongPropertyProvider
    {
        public override float Order => 56.0f;
        public override string Key => Parameters.AFFISE_SESSION_COUNT;
        private readonly ISessionManager _sessionManager;

        public AffiseSessionCountProvider(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        public override long? Provide()
        {
            var count = _sessionManager.GetSessionCount();
            return count == 0 ? 1 : count;
        }
    }
}