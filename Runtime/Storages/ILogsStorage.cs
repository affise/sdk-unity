using System.Collections.Generic;
using AffiseAttributionLib.Logs;

namespace AffiseAttributionLib.Storages
{
    internal interface ILogsStorage
    {
        void SaveLog(string key, string subKey, SerializedLog log);
        List<SerializedLog> GetLogs(string key, List<string> subKeys);
        void DeleteLogs(string key, IEnumerable<string> subKeys, IEnumerable<string> ids);
        void Clear();
        bool HasLogs(string key, List<string> subKeys);
    }
}