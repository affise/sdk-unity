using System.Collections.Generic;
using AffiseAttributionLib.Events.Subscription;
using AffiseAttributionLib.Storages;

namespace AffiseAttributionLib.Events
{
    /**
     * Event use case for IsFirstForUser
     *
     * @property isFirstForUserStorage storage of already send events
     */
    internal class IsFirstForUserUseCaseImpl : IIsFirstForUserUseCase
    {
        /**
         * Cache of already send events
         */
        private readonly List<string> _cache;

        private readonly IIsFirstForUserStorage _isFirstForUserStorage;

        public IsFirstForUserUseCaseImpl(IIsFirstForUserStorage isFirstForUserStorage)
        {
            _isFirstForUserStorage = isFirstForUserStorage;
            _cache = _isFirstForUserStorage.GetEventNames();
        }

        /**
         * Update IsFirstForUser
         */
        public void UpdateEvent(AffiseEvent affiseEvent)
        {
            var eventClass = affiseEvent.GetName();
            if (affiseEvent is BaseSubscriptionEvent subscriptionEvent)
            {
                eventClass = subscriptionEvent.SubType();
            }

            if (_cache.Contains(eventClass))
            {
                affiseEvent.SetFirstForUser(false);
            }
            else
            {
                _cache.Add(eventClass);
                _isFirstForUserStorage.Add(eventClass);
                affiseEvent.SetFirstForUser(true);
            }
        }
    }
}