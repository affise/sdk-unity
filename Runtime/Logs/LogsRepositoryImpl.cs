using System.Collections.Generic;
using System.Linq;
using AffiseAttributionLib.Converter;
using AffiseAttributionLib.AffiseParameters.Logs;
using AffiseAttributionLib.Storages;

namespace AffiseAttributionLib.Logs
{
    /**
     * Repository for logs models
     */
    internal class LogsRepositoryImpl : ILogsRepository
    {
        private readonly IConverter<string, string> _converterToBase64;
        private readonly IConverter<AffiseLog, SerializedLog> _converterToSerializedLog;
        private readonly ILogsStorage _logsStorage;

        public LogsRepositoryImpl(
            IConverter<string, string> converterToBase64,
            IConverter<AffiseLog, SerializedLog> converterToSerializedLog,
            ILogsStorage logsStorage
        )
        {
            _converterToBase64 = converterToBase64;
            _converterToSerializedLog = converterToSerializedLog;
            _logsStorage = logsStorage;
        }

        /**
         * Store [log]
         */
        public void StoreLog(AffiseLog log, IEnumerable<string> urls)
        {
            foreach (var url in urls)
            {
                _logsStorage.SaveLog(
                    _converterToBase64.Convert(url),
                    _converterToBase64.Convert(log.Name.Type()),
                    _converterToSerializedLog.Convert(log)
                );
            }
        }

        /**
         * Get logs by [url]
         * @return logs
         */
        public List<SerializedLog> GetLogs(string url) => _logsStorage.GetLogs(
            _converterToBase64.Convert(url),
            AffiseLogTypeExtensions.Values().Select(type => _converterToBase64.Convert(type.Type())).ToList()
        );

        /**
         * Removes all log by [ids] in [url]
         */
        public void DeleteLogs(IEnumerable<string> ids, string url)
        {
            _logsStorage.DeleteLogs(
                _converterToBase64.Convert(url),
                AffiseLogTypeExtensions.Values().Select(type => _converterToBase64.Convert(type.Type())),
                ids
            );
        }

        /**
         * Removes all Logs
         */
        public void Clear()
        {
            _logsStorage.Clear();
        }

        public bool HasLogs(string url)
        {
            return _logsStorage.HasLogs(
                _converterToBase64.Convert(url),
                AffiseLogTypeExtensions.Values().Select(type => _converterToBase64.Convert(type.Type())).ToList()
            );
        }
    }
}