#if UNITY_ANDROID
using System;
using AffiseAttributionLib.Logs;
using AffiseAttributionLib.Native;
using UnityEngine;

namespace Packages.Affise.Runtime.Native.Android
{
    internal class AndroidUseCase : INativeUseCase
    {
        private readonly ILogsManager _logsManager;
        private readonly AndroidJavaObject _plugin;

        public AndroidUseCase(ILogsManager logsManager)
        {
            _logsManager = logsManager;

            try
            {
                var unityContext = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
                var activity = unityContext.GetStatic<AndroidJavaObject>("currentActivity");
                var app = activity.Call<AndroidJavaObject>("getApplication");
                _plugin = new AndroidJavaObject("com.affise.attribution.AffiseUnityPlugin", app);
            }
            catch (Exception e)
            {
                _logsManager.AddSdkError(e);
            }
        }

        public long? GetInstalledTime()
        {
            try
            {
                return _plugin.Call<long>("getInstalledTime");
            }
            catch (Exception e)
            {
                _logsManager.AddDeviceError(e);
            }

            return null;
        }

        public long? GetInstalledBeginTime()
        {
            try
            {
                return _plugin.Call<long>("getInstalledBeginTime");
            }
            catch (Exception e)
            {
                _logsManager.AddDeviceError(e);
            }

            return null;
        }

        public string GetApiVersion()
        {
            try
            {
                return _plugin.Call<string>("getApiVersion");
            }
            catch (Exception e)
            {
                _logsManager.AddDeviceError(e);
            }

            return null;
        }

        public string GetOSVersion()
        {
            try
            {
                return _plugin.Call<string>("getOSVersion");
            }
            catch (Exception e)
            {
                _logsManager.AddDeviceError(e);
            }

            return null;
        }

        public string GetIsp()
        {
            try
            {
                return _plugin.Call<string>("getIsp");
            }
            catch (Exception e)
            {
                _logsManager.AddDeviceError(e);
            }

            return null;
        }

        public string GetAndroidId()
        {
            try
            {
                return _plugin.Call<string>("getAndroidId");
            }
            catch (Exception e)
            {
                _logsManager.AddDeviceError(e);
            }

            return null;
        }

        public string GetDeviceManufacturer()
        {
            try
            {
                return _plugin.Call<string>("getDeviceManufacturer");
            }
            catch (Exception e)
            {
                _logsManager.AddDeviceError(e);
            }

            return null;
        }

        public string GetConnectionType()
        {
            try
            {
                return _plugin.Call<string>("getConnectionType");
            }
            catch (Exception e)
            {
                _logsManager.AddDeviceError(e);
            }

            return null;
        }

        public string GetNetworkType()
        {
            try
            {
                return _plugin.Call<string>("getNetworkType");
            }
            catch (Exception e)
            {
                _logsManager.AddDeviceError(e);
            }

            return null;
        }

        public string GetStore()
        {
            try
            {
                return _plugin.Call<string>("getStore");
            }
            catch (Exception e)
            {
                _logsManager.AddDeviceError(e);
            }

            return null;
        }

        public string GetGaidAdid()
        {
            try
            {
                return _plugin.Call<string>("getGaidAdid");
            }
            catch (Exception e)
            {
                _logsManager.AddDeviceError(e);
            }

            return "error";
        }

        public string GetReferrer()
        {
            try
            {
                return _plugin.Call<string>("getReferrer");
            }
            catch (Exception e)
            {
                _logsManager.AddDeviceError(e);
            }

            return null;
        }

        public string GetReferrerInstallVersion()
        {
            try
            {
                return _plugin.Call<string>("getReferrerInstallVersion");
            }
            catch (Exception e)
            {
                _logsManager.AddDeviceError(e);
            }

            return null;
        }

        public long? GetReferrerClickTimestamp()
        {
            try
            {
                return _plugin.Call<long>("getReferrerClickTimestamp");
            }
            catch (Exception e)
            {
                _logsManager.AddDeviceError(e);
            }

            return null;
        }

        public long? GetReferrerClickTimestampServer()
        {
            try
            {
                return _plugin.Call<long>("getReferrerClickTimestampServer");
            }
            catch (Exception e)
            {
                _logsManager.AddDeviceError(e);
            }

            return null;
        }

        public bool? GetReferrerGooglePlayInstant()
        {
            try
            {
                return _plugin.Call<bool>("getReferrerGooglePlayInstant");
            }
            catch (Exception e)
            {
                _logsManager.AddDeviceError(e);
            }

            return null;
        }
    }
}
#endif