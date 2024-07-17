#nullable enable
using System;
using System.Collections.Generic;
using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Converter;
using AffiseAttributionLib.Executors;
using AffiseAttributionLib.Logs;
using AffiseAttributionLib.Modules;
using AffiseAttributionLib.Network;
using AffiseAttributionLib.Utils;

namespace AffiseAttributionLib.Module.Status.UseCase
{
    internal class CheckStatusUseCaseImpl : ICheckStatusUseCase
    {
        private const string Path = "check_status";
        private readonly string _url = CloudConfig.GetUrl(Path);

        private const int ATTEMPTS_TO_SEND = 30;
        private const long TIME_DELAY_SENDING = 5 * 1000;

        private readonly ILogsManager? _logsManager;
        private readonly IHttpClient _httpClient;
        private readonly IExecutorServiceProvider _executorServiceProvider;
        private readonly ProvidersToJsonStringConverter _converter;
        private readonly StringToKeyValueConverter _keyValueConverter;

        private readonly List<Provider> _providers;

        public CheckStatusUseCaseImpl(
            AffiseModule affiseModule,
            ILogsManager? logsManager,
            IHttpClient httpClient,
            IExecutorServiceProvider executorServiceProvider,
            ProvidersToJsonStringConverter converter,
            StringToKeyValueConverter keyValueConverter)
        {
            _logsManager = logsManager;
            _httpClient = httpClient;
            _executorServiceProvider = executorServiceProvider;
            _converter = converter;
            _keyValueConverter = keyValueConverter;
            _providers = affiseModule.GetRequestProviders();
        }

        public void Send(OnKeyValueCallback onComplete)
        {
            SendWithRepeat(onComplete, ATTEMPTS_TO_SEND);
        }

        private void SendWithRepeat(OnKeyValueCallback onComplete, int attempts)
        {
            CreateRequest((response) =>
            {
                if (response.IsValid())
                {
                    onComplete(_keyValueConverter.Convert(response.Body));
                }
                else
                {
                    if (--attempts == 0)
                    {
                        onComplete(new List<AffiseKeyValue>());
                    }
                    else
                    {
                        SendWithDelay(onComplete, attempts);
                    }
                }
            });
        }

        private void SendWithDelay(OnKeyValueCallback onComplete, int attempts)
        {
            _executorServiceProvider.ExecuteWithDelay(TIME_DELAY_SENDING,
                () => { SendWithRepeat(onComplete, attempts); });
        }

        private void CreateRequest(
            Action<HttpResponse>? onComplete = null
        )
        {
            _executorServiceProvider.Execute(
                _httpClient.ExecuteRequest(
                    _url,
                    IHttpClient.Method.POST,
                    _converter.Convert(_providers),
                    CloudConfig.Headers,
                    onComplete
                )
            );
        }
    }
}