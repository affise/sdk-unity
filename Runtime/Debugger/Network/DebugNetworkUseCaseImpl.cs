#nullable enable
using AffiseAttributionLib.Init;
using AffiseAttributionLib.Network;

namespace AffiseAttributionLib.Debugger.Network
{
    public class DebugNetworkUseCaseImpl : IDebugNetworkUseCase
    {
        private readonly AffiseInitProperties _initProperties;
        private readonly IHttpClient _httpClient;

        public DebugNetworkUseCaseImpl(AffiseInitProperties initProperties, IHttpClient httpClient)
        {
            _initProperties = initProperties;
            _httpClient = httpClient;
        }

        public void OnRequest(DebugOnNetworkCallback onDebug)
        {
            if (_initProperties.IsProduction) return;
            _httpClient.SetDebug(onDebug);
        }
    }
}