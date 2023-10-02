using AffiseAttributionLib.AffiseParameters.Logs;

namespace AffiseAttributionLib.Logs
{
    /**
     * UseCase store logs interface
     */
    internal interface IStoreLogsUseCase
    {
        /**
         * Store log
         */
        void StoreLog(AffiseLog log);
    }
}