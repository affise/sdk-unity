using AffiseAttributionLib.Logs;
#if UNITY_STANDALONE_WIN
using Packages.Affise.Runtime.Native.Windows;
#elif UNITY_IOS
using Packages.Affise.Runtime.Native.IOS;
#endif


namespace AffiseAttributionLib.Native
{
    internal class NativeUseCaseImpl : INativeUseCase
    {
        private readonly INativeUseCase _platform = null;

        public NativeUseCaseImpl(ILogsManager logsManager)
        {
#if UNITY_IOS
            _platform = new IOSUseCase(logsManager);
#elif UNITY_STANDALONE_WIN
            _platform = new WindowsUseCase(logsManager);
#endif
        }

        public long? GetInstalledTime() => _platform?.GetInstalledTime();
        
        public long? GetInstalledBeginTime() => _platform?.GetInstalledBeginTime();

        public string GetApiVersion() => _platform?.GetApiVersion();

        public string GetOSVersion() => _platform?.GetOSVersion();
        
        public string GetIsp() => _platform?.GetIsp();
        
        public string GetAndroidId() => _platform?.GetAndroidId();
        
        public string GetDeviceManufacturer() => _platform?.GetDeviceManufacturer();
        
        public string GetConnectionType() => _platform?.GetConnectionType();
        
        public string GetNetworkType() => _platform?.GetNetworkType();
        
        public string GetStore() => _platform?.GetStore();
        
        public string GetGaidAdid() => _platform?.GetGaidAdid();
        
        public string GetReferrer() => _platform?.GetReferrer();

        public string GetReferrerInstallVersion() => _platform?.GetReferrerInstallVersion();

        public long? GetReferrerClickTimestamp() => _platform?.GetReferrerClickTimestamp();

        public long? GetReferrerClickTimestampServer() => _platform?.GetReferrerClickTimestampServer();

        public bool? GetReferrerGooglePlayInstant() => _platform?.GetReferrerGooglePlayInstant();
    }
}