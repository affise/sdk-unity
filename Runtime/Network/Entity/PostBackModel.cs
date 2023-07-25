using System.Collections.Generic;
using AffiseAttributionLib.Events;
using AffiseAttributionLib.Logs;

namespace AffiseAttributionLib.Network.Entity
{
    public class PostBackModel
    {
        public readonly Dictionary<string, object> Parameters;
        public readonly List<SerializedEvent> Events;
        public readonly List<SerializedLog> Logs;

        public PostBackModel(
            Dictionary<string, object> parameters,
            List<SerializedEvent> events,
            List<SerializedLog> logs
        )
        {
            Parameters = parameters;
            Events = events;
            Logs = logs;
        }
    }
}