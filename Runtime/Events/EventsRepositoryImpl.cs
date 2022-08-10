using System.Collections.Generic;
using AffiseAttributionLib.Converter;
using AffiseAttributionLib.Storages;

namespace AffiseAttributionLib.Events
{
    public class EventsRepositoryImpl : IEventsRepository
    {
        private readonly IConverter<string, string> _converterToBase64;
        private readonly IConverter<AffiseEvent, SerializedEvent> _eventToSerializedEventConverter;
        private readonly IEventsStorage _eventsStorage;

        public EventsRepositoryImpl(
            IConverter<string, string> converterToBase64,
            IConverter<AffiseEvent, SerializedEvent> eventToSerializedEventConverter,
            IEventsStorage eventsStorage
        )
        {
            _converterToBase64 = converterToBase64;
            _eventToSerializedEventConverter = eventToSerializedEventConverter;
            _eventsStorage = eventsStorage;
        }

        public void StoreEvent(AffiseEvent affiseEvent, IEnumerable<string> urls)
        {
            foreach (var url in urls)
            {
                _eventsStorage.SaveEvent(
                    _converterToBase64.Convert(url),
                    _eventToSerializedEventConverter.Convert(affiseEvent)
                );
            }
        }

        public List<SerializedEvent> GetEvents(string url)
        {
            return _eventsStorage.GetEvents(
                _converterToBase64.Convert(url)
            );
        }

        public void DeleteEvent(IEnumerable<string> ids, string url)
        {
            _eventsStorage.DeleteEvent(
                _converterToBase64.Convert(url),
                ids
            );
        }

        public void Clear()
        {
            _eventsStorage.Clear();
        }

        public bool HasEvents(string url)
        {
            return _eventsStorage.HasEvent(
                _converterToBase64.Convert(url)
            );
        }
    }
}