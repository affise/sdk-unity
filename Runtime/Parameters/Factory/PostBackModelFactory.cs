#nullable enable
using System.Collections.Generic;
using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Events;
using AffiseAttributionLib.Logs;
using AffiseAttributionLib.Network.Entity;

namespace AffiseAttributionLib.AffiseParameters.Factory
{
    internal class PostBackModelFactory
    {
        private readonly List<Provider> _providers;
        public PostBackModelFactory(
            List<Provider> providers
        )
        {
            _providers = providers;
        }

        public PostBackModel Create(List<SerializedEvent> events, List<SerializedLog> logs)
        {
            return new PostBackModel(
                parameters: MapProviders(),
                events: events,
                logs: logs
            );
        }

        public T? GetProvider<T>() where T : Provider
        {
            return _providers.GetProvider<T>();
        }

        public List<Provider> GetProviders() => _providers;

        private Dictionary<string, object> MapProviders()
        {
            return _providers.MapProviders();
        }
    }
}