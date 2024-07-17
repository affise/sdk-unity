using System.Collections.Generic;
using AffiseAttributionLib.AffiseParameters.Factory;
using AffiseAttributionLib.Converter;
using AffiseAttributionLib.Events;
using AffiseAttributionLib.Executors;
using AffiseAttributionLib.Logs;
using AffiseAttributionLib.Network;
using AffiseAttributionLib.Network.Entity;
using AffiseAttributionLib.Utils;

namespace AffiseAttributionLib.Usecase
{
    internal class ImmediateSendToServerUseCaseImpl : IImmediateSendToServerUseCase
    {
        private readonly IExecutorServiceProvider _executorServiceProvider;
        private readonly ICloudRepository _cloudRepository;
        private readonly PostBackModelFactory _postBackModelFactory;
        private readonly IConverter<AffiseEvent, SerializedEvent> _eventToSerializedEventConverter;
        private readonly ILogsManager _logsManager;

        public ImmediateSendToServerUseCaseImpl(
            IExecutorServiceProvider executorServiceProvider,
            ICloudRepository cloudRepository,
            PostBackModelFactory postBackModelFactory,
            IConverter<AffiseEvent, SerializedEvent> eventToSerializedEventConverter,
            ILogsManager logsManager
        )
        {
            _executorServiceProvider = executorServiceProvider;
            _cloudRepository = cloudRepository;
            _postBackModelFactory = postBackModelFactory;
            _eventToSerializedEventConverter = eventToSerializedEventConverter;
            _logsManager = logsManager;
        }


        public void SendNow(AffiseEvent affiseEvent, OnSendSuccessCallback success, OnSendFailedCallback failed)
        {
            foreach (var url in CloudConfig.GetUrls())
            {
                Send(affiseEvent, url, success, failed);
            }
        }

        private void Send(AffiseEvent affiseEvent, string url, OnSendSuccessCallback success,
            OnSendFailedCallback failed)
        {
            // Serialize event
            var serializedEvent = _eventToSerializedEventConverter.Convert(affiseEvent);

            // Generate data
            var data = new List<PostBackModel>
            {
                _postBackModelFactory.Create(
                    new List<SerializedEvent>()
                    {
                        serializedEvent
                    },
                    new List<SerializedLog>()
                )
            };

            // Send data for single url
            _cloudRepository.Send(
                data,
                url,
                response =>
                {
                    if (response.IsValid())
                    {
                        success.Invoke();
                    }
                    else
                    {
                        failed.Invoke(response);
                    }
                }
            );
        }
    }
}