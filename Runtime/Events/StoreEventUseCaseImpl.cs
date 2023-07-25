using AffiseAttributionLib.Network;

namespace AffiseAttributionLib.Events
{
    internal class StoreEventUseCaseImpl : IStoreEventUseCase
    {
        private readonly IEventsRepository _eventsRepository;
        private readonly EventsManager _eventsManager;
        private readonly IIsFirstForUserUseCase _isFirstForUserUseCase;

        public StoreEventUseCaseImpl(
            IEventsRepository eventsRepository,
            EventsManager eventsManager,
            IIsFirstForUserUseCase isFirstForUserUseCase)
        {
            _eventsRepository = eventsRepository;
            _eventsManager = eventsManager;
            _isFirstForUserUseCase = isFirstForUserUseCase;
        }

        public void StoreEvent(AffiseEvent affiseEvent)
        {
            //Update event for isFirstForUser
            _isFirstForUserUseCase.UpdateEvent(affiseEvent);
            //Save event
            _eventsRepository.StoreEvent(affiseEvent, CloudConfig.GetUrls());
            //Send events
            _eventsManager.SendEvents();
        }
    }
}