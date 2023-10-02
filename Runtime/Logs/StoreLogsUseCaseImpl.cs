using AffiseAttributionLib.Network;
using AffiseAttributionLib.AffiseParameters.Logs;

namespace AffiseAttributionLib.Logs
{
    internal class StoreLogsUseCaseImpl : IStoreLogsUseCase
    {
        private readonly ILogsRepository _logsRepository;

        public StoreLogsUseCaseImpl(ILogsRepository logsRepository)
        {
            _logsRepository = logsRepository;
        }

        /**
         * Store [log]
         */
        public void StoreLog(AffiseLog log)
        {
            _logsRepository.StoreLog(log, CloudConfig.GetUrls() );
        }
    }
}