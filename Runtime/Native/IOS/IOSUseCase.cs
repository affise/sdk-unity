#if UNITY_IOS
using AffiseAttributionLib.Logs;
using AffiseAttributionLib.Native;
using UnityEngine.iOS;
using UnityEngine;

namespace AffiseAttributionLib.Native.IOS
{
    internal class IOSUseCase : INativeUseCase
    {
        private readonly ILogsManager _logsManager;

        public IOSUseCase(ILogsManager logsManager)
        {
            _logsManager = logsManager;
        }

        public long? GetInstalledTime()
        {
            return null;
        }

        public string GetApiVersion()
        {
            return Device.systemVersion;
        }

        public string GetOSVersion()
        {
            return Device.systemVersion;
        }

        public string GetIsp()
        {
            return null;
        }

        public string GetAndroidId()
        {
            return SystemInfo.deviceUniqueIdentifier;
        }

        public string GetDeviceManufacturer()
        {
            return "Apple";
        }

        public string GetStore()
        {
            return "App Store";
        }
    }
}
#endif