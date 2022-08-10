using System;
using AffiseAttributionLib.Extensions;
using AffiseAttributionLib.AffiseParameters;

namespace AffiseAttributionLib.Session
{
    public class SessionManagerImpl : ISessionManager
    {
        private const long TIME_TO_START_SESSION = 15 * 1000L;

        /**
         * Time of start session
         */
        private long? _openAppTime = null;

        /**
         * Last time of user active
         */
        private long? _closeAppTime = null;

        /**
         * Session active status
         */
        private bool _sessionActive = false;

        /**
         * Open app status
         */
        private bool _isOpenApp = false;

        private readonly ICurrentActiveActivityCountProvider _activityCountProvider;

        public SessionManagerImpl(ICurrentActiveActivityCountProvider activityCountProvider)
        {
            _activityCountProvider = activityCountProvider;
        }

        /**
         * Start manager
         */
        public void Init()
        {
            SubscribeToActivityEvents();
        }

        /**
         * Subscribe to change open activity count
         */
        private void SubscribeToActivityEvents()
        {
            _activityCountProvider.AddActivityCountListener(count =>
            {
                //Check open activity count
                if (count > 0)
                {
                    //App is open
                    _isOpenApp = true;

                    // Check create open app time
                    if (_openAppTime is not null) return;

                    //open app time
                    _openAppTime = GetTimeMillis();
                }
                else
                {
                    //Update session status if need
                    CheckSessionToStart();

                    //Save time of user quit or hide app
                    _closeAppTime = GetTimeMillis();

                    //App is close
                    _isOpenApp = false;

                    //Drop session status
                    _sessionActive = false;

                    //Save sessionTime
                    SaveSessionTime();

                    //Drop open app time
                    _openAppTime = null;
                }
            });
        }

        /**
         * Get session active status
         *
         * @return session status
         */
        public bool IsSessionActive()
        {
            //Check session status
            CheckSessionToStart();

            //Return session status
            return _sessionActive;
        }

        /**
         * Getting the last time the user was in the application
         * @return time
         */
        public long? GetLastInteractionTime()
        {
            //Current time if app is open
            if (_isOpenApp) return GetTimeMillis();

            //lastInteractionTime is session is active
            return _closeAppTime;
        }

        /**
         * Get current session time
         */
        public long GetSessionTime()
        {
            if (_openAppTime is null) return 0;

            return GetTimeMillis() - (_openAppTime ?? 0);
        }

        /**
         * Get all sessions time
         */
        public long GetLifetimeSessionTime()
        {
            return GetSaveSessionsTime() + GetSessionTime();
        }

        /**
         * Get session cont
         */
        public long GetSessionCount()
        {
            //Check session status
            if (!_sessionActive)
            {
                CheckSessionToStart();
            }

            return PlayerPrefsExt.GetLong(Parameters.AFFISE_SESSION_COUNT, 0L);
        }
        
        /**
         * Get session start
         */
        public long? GetSessionStartTime()
        {
            return _openAppTime;
        }

        /**
         * Check time of start app and start session
         */
        private void CheckSessionToStart()
        {
            if (_sessionActive) return;

            //Check open app time
            if (_openAppTime is null) return;

            //Time current session
            var time = GetTimeMillis() - _openAppTime - TIME_TO_START_SESSION;

            //if session started
            if (time <= 0) return;

            _sessionActive = true;

            //Save new session
            AddNewSession();
        }

        /**
         * Save session time
         */
        private void SaveSessionTime()
        {
            PlayerPrefsExt.SetLong(Parameters.LIFETIME_SESSION_COUNT, GetLifetimeSessionTime());
        }

        /**
         * Get all old sessions time
         */
        private long GetSaveSessionsTime() => PlayerPrefsExt.GetLong(Parameters.LIFETIME_SESSION_COUNT, 0L);

        /**
         * Save new session count
         */
        private void AddNewSession()
        {
            var count = PlayerPrefsExt.GetLong(Parameters.AFFISE_SESSION_COUNT, 0L);
            PlayerPrefsExt.SetLong(Parameters.AFFISE_SESSION_COUNT, count + 1);
        }

        private long GetTimeMillis()
        {
            return DateTime.UtcNow.GetTimeInMillis();
        }
    }
}