#nullable enable
using System.Collections.Generic;
using AffiseAttributionLib.AffiseParameters;
using AffiseAttributionLib.Events;
using AffiseAttributionLib.Logs;

namespace AffiseAttributionLib.Network.Entity
{
    public class PostBackModel
    {
        public readonly Dictionary<ProviderType, object?> Parameters;
        public readonly List<SerializedEvent> Events;
        public readonly List<SerializedLog> Logs;

        public PostBackModel(
            Dictionary<ProviderType, object?> parameters,
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