using AffiseAttributionLib.Executors;
using AffiseAttributionLib.Usecase;

namespace AffiseAttributionLib.Events
{
    internal class EventsManager
    {
        private const float TIME_SEND_REPEAT = 15f;

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
            SendEventsNoDelay();
            _executorServiceProvider.ExecuteWithDelay(SendEventsNoDelay, TIME_SEND_REPEAT);
        }

        public void SendEvents()
        {
            _sendDataToServerUseCase.Send();
        }
        
        private void SendEventsNoDelay()
        {
            _sendDataToServerUseCase.Send(false);
        }
    }
}