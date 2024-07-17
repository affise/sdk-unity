#nullable enable
using AffiseAttributionLib.Executors;
using AffiseAttributionLib.Module.Link.UseCase;
using AffiseAttributionLib.Modules;
using AffiseAttributionLib.Network;

namespace AffiseAttributionLib.Module.Link
{
    public class LinkModule : AffiseModule, IAffiseLinkApi
    {
        private ILinkResolveUseCase? _useCase;
        
        public override void Start()
        {
            var httpClient = Get<IHttpClient>();
            if (httpClient is null) return;
            _useCase = new LinkResolveUseCaseImpl(
                httpClient,
                new ExecutorServiceProviderImpl()
            );
        }

        public void LinkResolve(string uri, AffiseLinkCallback callback)
        {
            _useCase?.LinkResolve(uri, callback);
        }
    }
}