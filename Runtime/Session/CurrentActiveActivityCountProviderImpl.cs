using System;
using AffiseAttributionLib.Utils;

namespace AffiseAttributionLib.Session
{
    internal class CurrentActiveActivityCountProviderImpl : ICurrentActiveActivityCountProvider
    {
        private readonly IActivityActionsManager _activityActionsManager;

        /**
         * Count of open activity
         */
        private long _activityCount;

        /**
         * Listener of change count of open activity
         */
        public event Action<long> OnActivityCount = delegate { };

        /**
         * Listener of start activity
         */
        private Action _onStartedSubscription;
        
        /**
         * Listener of stop activity
         */
        private Action _onStoppedSubscription;

        public CurrentActiveActivityCountProviderImpl(IActivityActionsManager activityActionsManager)
        {
            _activityActionsManager = activityActionsManager;
        }

        /**
         * Start provider
         */
        public void Init()
        {
            if (_onStartedSubscription is null)
            {
                _onStartedSubscription = () => {
                    //Update open activity count
                    _activityCount += 1;
                    //Notify new count
                    OnActivityCount.Invoke(_activityCount);
                };
                _activityActionsManager.OnActivityStarted += _onStartedSubscription;
            }
            if (_onStoppedSubscription is null)
            {
                _onStoppedSubscription = () =>
                {
                    //Update open activity count
                    _activityCount -= 1;
                    //Notify new count
                    OnActivityCount.Invoke(_activityCount);
                };
                _activityActionsManager.OnActivityStopped += _onStartedSubscription;
            }
        }
        
        /**
         * Add [listener] for change activity count
         */
        public void AddActivityCountListener(Action<long> listener)
        {
            OnActivityCount += listener;
        }

        /**
         * Get current open activities count
         */
        public long GetActivityCount() => _activityCount;
    }
}