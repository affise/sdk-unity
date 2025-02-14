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

    internal static class PostBackModelExt
    {
        public static PostBackModel AsFirstOpen(this PostBackModel model)
        {
            var parameters = model.Parameters;
            parameters[ProviderType.INSTALL_FIRST_EVENT] = true;
            return new PostBackModel(
                parameters: parameters,
                events: model.Events,
                logs: model.Logs
            );
        }
    }
}