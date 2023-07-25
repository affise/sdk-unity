namespace AffiseAttributionLib.Session
{
    public interface ISessionManager
    {
        /**
         * Init Manager
         */
        void Init();

        /**
         * Get session active status
         *
         * @return session is active or not
         */
        bool IsSessionActive();

        /**
         * Get last interaction time
         *
         * @return Last interaction time
         */
        long? GetLastInteractionTime();

        /**
         * Get session time
         *
         * @return session time
         */
        long GetSessionTime();

        /**
         * Get lifetime session time
         *
         * @return lifetime session time
         */
        long GetLifetimeSessionTime();

        /**
         * Get session count
         *
         * @return session count
         */
        long GetSessionCount();
        
        /**
         * Get session start time
         *
         * @return session start time
         */
        long? GetSessionStartTime();

        void SessionStart();
    }
}