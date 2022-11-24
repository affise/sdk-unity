using System.Collections.Generic;
using AffiseAttributionLib.Events;
using AffiseAttributionLib.Logs;

namespace AffiseAttributionLib.Network.Entity
{
    public class PostBackModel
    {
        public readonly string Uuid;
        public readonly string AffiseAppId;
        public readonly string AffisePkgAppName;
        public readonly string AppVersion;
        public readonly string AppVersionRaw;
        public readonly string Store;
        public readonly long? InstalledTime;
        public readonly long? FirstOpenTime;
        public readonly long? InstalledHour;
        public readonly long? FirstOpenHour;
        public readonly bool? InstallFirstEvent;
        public readonly long? InstallBeginTime;
        public readonly long? InstallFinishTime;
        public readonly string ReferrerInstallVersion;
        public readonly long? ReferrerClickTimestamp;
        public readonly long? ReferrerClickTimestampServer;
        public readonly bool? ReferrerGooglePlayInstant;
        public readonly long? CreatedTime;
        public readonly long? CreatedTimeMilli;
        public readonly long? CreatedTimeHour;
        public readonly long? LastSessionTime;
        public readonly string ConnectionType;
        public readonly string CpuType;
        public readonly string HardwareName;
        public readonly string NetworkType;
        public readonly string DeviceManufacturer;
        public readonly bool? DeeplinkClick;
        public readonly string AffDeviceId;
        public readonly string AffAltDeviceId;
        public readonly string AndroidId;
        public readonly string GaidAdid;
        public readonly string GaidAdidMd5;
        public readonly string Reftoken;
        public readonly string Referrer;
        public readonly string UserAgent;
        public readonly string Isp;
        public readonly string Language;
        public readonly string DeviceName;
        public readonly string DeviceType;
        public readonly string OsName;
        public readonly string Platform;
        public readonly string APILevelOs;
        public readonly string AffSdkVersion;
        public readonly string OSVersion;
        public readonly string RandomUserId;
        public readonly string TimezoneDev;
        public readonly string AffSdkPos;
        public readonly string AffAppToken;
        public readonly long? LastTimeSession;
        public readonly long? TimeSession;
        public readonly long? AffSessionCount;
        public readonly long? AffAppOpened;
        public readonly long? LifetimeSessionCount;
        public readonly string AffDeeplink;
        public readonly string AffPartParamName;
        public readonly string AffPartParamNameToken;
        public readonly string AffsdkSecretId;
        public readonly string Pushtoken;
        public readonly List<SerializedEvent> Events;
        public readonly List<SerializedLog> Logs;

        public PostBackModel(string uuid,
            string affiseAppId,
            string affisePkgAppName,
            string appVersion,
            string appVersionRaw,
            string store,
            long? installedTime,
            long? firstOpenTime,
            long? installedHour,
            long? firstOpenHour,
            bool? installFirstEvent,
            long? installBeginTime,
            long? installFinishTime,
            string referrerInstallVersion,
            long? referrerClickTimestamp,
            long? referrerClickTimestampServer,
            bool? referrerGooglePlayInstant,
            long? createdTime,
            long? createdTimeMilli,
            long? createdTimeHour,
            long? lastSessionTime,
            string connectionType,
            string cpuType,
            string hardwareName,
            string networkType,
            string deviceManufacturer,
            bool? deeplinkClick,
            string affDeviceId,
            string affAltDeviceId,
            string androidId,
            string gaidAdid,
            string gaidAdidMd5,
            string reftoken,
            string referrer,
            string userAgent,
            string isp,
            string language,
            string deviceName,
            string deviceType,
            string osName,
            string platform,
            string apiLevelOs,
            string affSdkVersion,
            string osVersion,
            string randomUserId,
            string affSdkPos,
            string timezoneDev,
            string affAppToken,
            long? lastTimeSession,
            long? timeSession,
            long? affSessionCount,
            long? affAppOpened,
            long? lifetimeSessionCount,
            string affDeeplink,
            string affPartParamName,
            string affPartParamNameToken,
            string affsdkSecretId,
            string pushtoken,
            List<SerializedEvent> events,
            List<SerializedLog> logs
        )
        {
            Uuid = uuid;
            AffiseAppId = affiseAppId;
            AffisePkgAppName = affisePkgAppName;
            AppVersion = appVersion;
            AppVersionRaw = appVersionRaw;
            Store = store;
            InstalledTime = installedTime;
            FirstOpenTime = firstOpenTime;
            InstalledHour = installedHour;
            FirstOpenHour = firstOpenHour;
            InstallFirstEvent = installFirstEvent;
            InstallBeginTime = installBeginTime;
            InstallFinishTime = installFinishTime;
            ReferrerInstallVersion = referrerInstallVersion;
            ReferrerClickTimestamp = referrerClickTimestamp;
            ReferrerClickTimestampServer = referrerClickTimestampServer;
            ReferrerGooglePlayInstant = referrerGooglePlayInstant;
            CreatedTime = createdTime;
            CreatedTimeMilli = createdTimeMilli;
            CreatedTimeHour = createdTimeHour;
            LastSessionTime = lastSessionTime;
            ConnectionType = connectionType;
            CpuType = cpuType;
            HardwareName = hardwareName;
            NetworkType = networkType;
            DeviceManufacturer = deviceManufacturer;
            DeeplinkClick = deeplinkClick;
            AffDeviceId = affDeviceId;
            AffAltDeviceId = affAltDeviceId;
            AndroidId = androidId;
            GaidAdid = gaidAdid;
            GaidAdidMd5 = gaidAdidMd5;
            Reftoken = reftoken;
            Referrer = referrer;
            UserAgent = userAgent;
            Isp = isp;
            Language = language;
            DeviceName = deviceName;
            DeviceType = deviceType;
            OsName = osName;
            Platform = platform;
            APILevelOs = apiLevelOs;
            AffSdkVersion = affSdkVersion;
            OSVersion = osVersion;
            RandomUserId = randomUserId;
            TimezoneDev = timezoneDev;
            AffSdkPos = affSdkPos;
            AffAppToken = affAppToken;
            LastTimeSession = lastTimeSession;
            TimeSession = timeSession;
            AffSessionCount = affSessionCount;
            AffAppOpened = affAppOpened;
            LifetimeSessionCount = lifetimeSessionCount;
            AffDeeplink = affDeeplink;
            AffPartParamName = affPartParamName;
            AffPartParamNameToken = affPartParamNameToken;
            AffsdkSecretId = affsdkSecretId;
            Pushtoken = pushtoken;
            Events = events;
            Logs = logs;
        }
    }
}