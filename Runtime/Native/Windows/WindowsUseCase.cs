using AffiseAttributionLib.Logs;
using AffiseAttributionLib.Native;
using UnityEngine;

namespace Packages.Affise.Runtime.Native.Windows
{
    internal class WindowsUseCase : INativeUseCase
    {
        private readonly ILogsManager _logsManager;
        private readonly string _osVersion;

        public WindowsUseCase(ILogsManager logsManager)
        {
            _logsManager = logsManager;
            _osVersion = WindowsUtils.GetOSVersion();
        }

        public string GetApiVersion() => _osVersion;

        public string GetOSVersion() => _osVersion;

        public string GetAndroidId()
        {
            return SystemInfo.deviceUniqueIdentifier;
        }

        public string GetStore()
        {
            return "exe";
        }
    }
}