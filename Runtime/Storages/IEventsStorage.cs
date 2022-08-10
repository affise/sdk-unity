using System.Collections.Generic;
using AffiseAttributionLib.Events;

namespace AffiseAttributionLib.Storages
{
    public interface IEventsStorage
    {
        void SaveEvent(string key, SerializedEvent affiseEvent);
        List<SerializedEvent> GetEvents(string key);
        void DeleteEvent(string key, IEnumerable<string> ids);
        void Clear();
        bool HasEvent(string key);
    }
}