using AffiseAttributionLib.Network;

namespace AffiseAttributionLib.Events
{
    internal class StoreEventUseCaseImpl : IStoreEventUseCase
    {
        private readonly IEventsRepository _eventsRepository;
        private readonly EventsManager _eventsManager;

        public StoreEventUseCaseImpl(
            IEventsRepository eventsRepository,
            EventsManager eventsManager
        )
        {
            _eventsRepository = eventsRepository;
            _eventsManager = eventsManager;
        }

        public void StoreEvent(AffiseEvent affiseEvent)
        {
            _eventsRepository.StoreEvent(affiseEvent, CloudConfig.GetUrls());
            _eventsManager.SendEvents();
        }
    }
}