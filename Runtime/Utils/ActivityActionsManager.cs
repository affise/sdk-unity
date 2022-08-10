using System;

namespace AffiseAttributionLib.Utils
{
    internal interface IActivityActionsManager
    {
        /**
         * Add [listener] for start activities
         */
        public event Action OnActivityStarted;
        
        /**
         * Add [listener] for stop activities
         */
        public event Action OnActivityResumed;
        
        /**
         * Add [listener] for stop activities
         */
        public event Action OnActivityStopped;
        
        public event Action<string> OnDeepLinkActivated;
    }
}