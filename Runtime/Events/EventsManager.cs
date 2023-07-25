using AffiseAttributionLib.Executors;
using AffiseAttributionLib.Usecase;

namespace AffiseAttributionLib.Events
{
    internal class EventsManager
    {
        private const long TIME_SEND_REPEAT = 15 * 1000;

        private readonly ISendDataToServerUseCase _sendDataToServerUseCase;
        private readonly IExecutorServiceProvider _executorServiceProvider;

        public EventsManager(
            IExecutorServiceProvider executorServiceProvider,
            ISendDataToServerUseCase sendDataToServerUseCase
        )
        {
            _executorServiceProvider = executorServiceProvider;
            _sendDataToServerUseCase = sendDataToServerUseCase;
        }

        public void Init()
        {
            sendEventsOnStart();
        }

        public void SendEvents(bool withDelay = true)
        {
            _sendDataToServerUseCase.Send(withDelay);
        }

        private void sendEventsOnStart()
        {
            //Send events on start
            SendEvents(false);
            
            //Start timer fo repeat send events
            _executorServiceProvider.ExecuteWithDelay(TIME_SEND_REPEAT, () =>
            {
                SendEvents();
            });
        }
    }
}