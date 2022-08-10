using System.Collections.Generic;

namespace AffiseAttributionLib.Events
{
    /**
     * Events repository interface
     */
    public interface IEventsRepository
    {
        /**
         * Event recording for each url
         */
        void StoreEvent(AffiseEvent affiseEvent, IEnumerable<string> urls);
        
        /**
         * Get event in dir
         */
        List<SerializedEvent> GetEvents(string url);

        /**
         * Delete events in dir
         */
        void DeleteEvent(IEnumerable<string> ids, string url);

        /**
         * Removes all events
         */
        void Clear();

        bool HasEvents(string url);
    }
}