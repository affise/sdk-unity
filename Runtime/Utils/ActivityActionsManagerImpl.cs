using System;

namespace AffiseAttributionLib.Utils
{
    internal class ActivityActionsManagerImpl : IActivityActionsManager
    {
        /**
         * Listeners for start activities
         */
        public event Action OnActivityStarted = delegate { };

        /**
         * Listeners for resume activities
         */
        public event Action OnActivityResumed = delegate { };

        /**
         * Listeners for stop activities
         */
        public event Action OnActivityStopped = delegate { };

        public event Action<string> OnDeepLinkActivated = delegate { };

        public ActivityActionsManagerImpl()
        {
            AffiseWorker.OnStart += () => { OnActivityStarted.Invoke(); };

            AffiseWorker.OnPause += (pauseStatus) =>
            {
#if UNITY_IOS
                if (pauseStatus) {
                    OnActivityStopped.Invoke();
                }
#endif
            };

            AffiseWorker.OnFocus += (hasFocus) => { };

            AffiseWorker.OnQuit += () => { OnActivityStopped.Invoke(); };

            AffiseWorker.OnDeepLink += (uri) => { OnDeepLinkActivated.Invoke(uri); };
        }
    }
}