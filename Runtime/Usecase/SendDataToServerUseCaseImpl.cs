using System;
using System.Collections.Generic;
using System.Linq;
using AffiseAttributionLib.AffiseParameters.Factory;
using AffiseAttributionLib.Events;
using AffiseAttributionLib.Exceptions;
using AffiseAttributionLib.Executors;
using AffiseAttributionLib.Logs;
using AffiseAttributionLib.Network;
using AffiseAttributionLib.Network.Entity;

namespace AffiseAttributionLib.Usecase
{
    internal class SendDataToServerUseCaseImpl : ISendDataToServerUseCase
    {
        private const float TIME_DELAY_SENDING = 15f;

        private readonly IExecutorServiceProvider _executorServiceProvider;
        private readonly PostBackModelFactory _postBackModelFactory;
        private readonly ICloudRepository _cloudRepository;
        private readonly IEventsRepository _eventsRepository;
        private readonly ILogsRepository _logsRepository;
        private readonly ILogsManager _logsManager;

        private readonly Dictionary<string, bool> _lockSend = CloudConfig.GetUrls().ToDictionary(
            key => key,
            value => false
        );

        private readonly Dictionary<string, int> _attemptSend = CloudConfig.GetUrls().ToDictionary(
            key => key,
            value => 0
        );

        public SendDataToServerUseCaseImpl(
            IExecutorServiceProvider executorServiceProvider,
            PostBackModelFactory postBackModelFactory,
            ICloudRepository cloudRepository,
            IEventsRepository eventsRepository,
            ILogsRepository logsRepository,
            ILogsManager logsManager
        )
        {
            _executorServiceProvider = executorServiceProvider;
            _postBackModelFactory = postBackModelFactory;
            _cloudRepository = cloudRepository;
            _eventsRepository = eventsRepository;
            _logsRepository = logsRepository;
            _logsManager = logsManager;
        }

        public void Send(bool withDelay = true)
        {
            foreach (var url in CloudConfig.GetUrls())
            {
                if (_lockSend[url]) continue;

                _lockSend[url] = true;

                if (withDelay)
                {
                    SendWithDelay(url, () =>
                    {
                        _lockSend[url] = false;
                        _attemptSend[url] = 0;
                    });
                }
                else
                {
                    Send(url, () =>
                    {
                        _lockSend[url] = false;
                        _attemptSend[url] = 0;
                    });
                }
            }
        }

        private bool IsToSendWithDelay(string url)
        {
            return _eventsRepository.HasEvents(url) || _logsRepository.HasLogs(url);
        }

        private void Send(string url, Action onComplete)
        {
            //Get events
            var events = _eventsRepository.GetEvents(url);

            //Get logs
            var logs = _logsRepository.GetLogs(url);

            // Send data for single url
            _cloudRepository.Send(
                PostBackModelsData(events, logs),
                url,
                success =>
                {
                    DeleteEvent(events, url);
                    DeleteLog(logs, url);

                    if (IsToSendWithDelay(url))
                    {
                        SendWithDelay(url, onComplete);
                    }
                    else
                    {
                        onComplete?.Invoke();
                    }
                }, error =>
                {
                    //Log error
                    _logsManager.AddNetworkError(new CloudException(url,
                        new NetworkException(error.Message, error.Status), _attemptSend[url], true));
                    _attemptSend[url] += 1;
                    SendWithDelay(url, onComplete);
                }
            );
        }

        private void SendWithDelay(string url, Action onComplete)
        {
            _executorServiceProvider.ExecuteWithDelay(() => { Send(url, onComplete); },
                TIME_DELAY_SENDING
            );
        }

        private List<PostBackModel> PostBackModelsData(List<SerializedEvent> events, List<SerializedLog> logs)
        {
            return new List<PostBackModel>
            {
                _postBackModelFactory.Create(events, logs)
            };
        }

        private void DeleteEvent(List<SerializedEvent> events, string url)
        {
            var ids = events.Select(s => s.Id);
            // Remove all sent events
            _eventsRepository.DeleteEvent(ids, url);
        }

        private void DeleteLog(List<SerializedLog> logs, string url)
        {
            var ids = logs.Select(s => s.Id);
            // Remove all sent logs
            _logsRepository.DeleteLogs(ids, url);
        }
    }
}