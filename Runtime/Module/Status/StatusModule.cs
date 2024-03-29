﻿#nullable enable
using System.Collections.Generic;
using AffiseAttributionLib.Converter;
using AffiseAttributionLib.Executors;
using AffiseAttributionLib.Module.Status.UseCase;
using AffiseAttributionLib.Modules;
using AffiseAttributionLib.Network;

namespace AffiseAttributionLib.Module.Status
{
    public class StatusModule : AffiseModule
    {
        private ICheckStatusUseCase? _checkStatusUseCase;

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
        }

        public override void Status(OnKeyValueCallback onComplete)
        {
            if (_checkStatusUseCase is not null)
            {
                _checkStatusUseCase?.Send(onComplete);
            }
            else
            {
                onComplete(new List<AffiseKeyValue>());
            }
        }
    }
}