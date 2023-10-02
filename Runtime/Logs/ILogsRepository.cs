using System.Collections.Generic;
using AffiseAttributionLib.AffiseParameters.Logs;

namespace AffiseAttributionLib.Logs
{
    /**
     * Logs repository interface
     */
    internal interface ILogsRepository
    {
        /**
         * Store log for all [urls]
         */
        void StoreLog(AffiseLog log, IEnumerable<string> urls);

        /**
         * Get log in current [url]
         */
        List<SerializedLog> GetLogs(string url);

        /**
         * Delete logs with [ids] in current [url]
         */
        void DeleteLogs(IEnumerable<string> ids, string url);

        /**
         * Removes all logs
         */
        void Clear();

        bool HasLogs(string url);
    }
}