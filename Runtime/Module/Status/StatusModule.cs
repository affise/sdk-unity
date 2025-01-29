#nullable enable
using System.Collections.Generic;
using AffiseAttributionLib.Converter;
using AffiseAttributionLib.Executors;
using AffiseAttributionLib.Module.Status.UseCase;
using AffiseAttributionLib.Modules;
using AffiseAttributionLib.Network;
using AffiseAttributionLib.Referrer;

namespace AffiseAttributionLib.Module.Status
{
    public class StatusModule : AffiseModule, ReferrerCallback
    {
        private ICheckStatusUseCase? _checkStatusUseCase;
        private IReferrerUseCase? _referrerUseCase;

        public override void Start()
        {
            var httpClient = Get<IHttpClient>();
            if (httpClient is null) return;
            var providersToJsonConverter = Get<ProvidersToJsonStringConverter>();
            if (providersToJsonConverter is null) return;

            _checkStatusUseCase = new CheckStatusUseCaseImpl(
                this,
                LogsManager,
                httpClient,
                new ExecutorServiceProviderImpl(),
                providersToJsonConverter,
                new StringToKeyValueConverter()
            );

            _referrerUseCase = new ReferrerUseCaseImpl(
                _checkStatusUseCase
            );
        }

        public override void Status(OnKeyValueCallback onComplete)
        {
            if (_checkStatusUseCase is not null)
            {
                _checkStatusUseCase?.Send((data) =>
                {
                    onComplete.Invoke(data);
                    _referrerUseCase?.ParseStatus(data);
                });
            }
            else
            {
                onComplete(new List<AffiseKeyValue>());
            }
        }

        public void GetReferrer(OnReferrerCallback callback)
        {
            _referrerUseCase?.GetReferrer(callback);
        }
    }
}