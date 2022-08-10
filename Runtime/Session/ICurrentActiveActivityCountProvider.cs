using System;

namespace AffiseAttributionLib.Session
{
    public interface ICurrentActiveActivityCountProvider
    {
        /**
         * Start provider
         */
        void Init();

        /**
         * Add [listener] to subscribe opened activity count
         */
        void AddActivityCountListener(Action<long> listener);

        /**
         * @return current foreground activity count
         */
        long GetActivityCount();
    }
}