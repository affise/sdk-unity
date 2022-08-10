using System.Collections.Generic;
using AffiseAttributionLib.Network.Entity;
using AffiseAttributionLib.AffiseParameters;
using SimpleJSON;

namespace AffiseAttributionLib.Converter
{
    public class PostBackModelToJsonStringConverter : IConverter<List<PostBackModel>, string>
    {
        private const string EVENTS_KEY = "events";
        private const string SDK_EVENTS_KEY = "sdk_events";

        public string Convert(List<PostBackModel> from)
        {
            var jsonArray = new JSONArray();
            foreach (var model in from)
            {
                var jsonObject = MakeParameters(model);
                jsonArray.Add(jsonObject);
            }

            return jsonArray.ToString();
        }

        private JSONObject MakeParameters(PostBackModel obj)
        {
            //Events
            var eventsArray = new JSONArray();
            foreach (var evt in obj.Events)
            {
                eventsArray.Add(evt.Data);
            }
            
            //Logs
            var logsArray = new JSONArray();
            foreach (var log in obj.Logs)
            {
                logsArray.Add(log.Data);
            }

            return new JSONObject
            {
                [Parameters.AFFISE_APP_ID] = obj.AffiseAppId,
                [Parameters.AFFISE_PKG_APP_NAME] = obj.AffisePkgAppName,
                [Parameters.APP_VERSION] = obj.AppVersion,
                [Parameters.APP_VERSION_RAW] = obj.AppVersionRaw,
                [Parameters.STORE] = obj.Store,

                [Parameters.INSTALLED_TIME] = obj.InstalledTime,
                [Parameters.FIRST_OPEN_TIME] = obj.FirstOpenTime,
                [Parameters.INSTALLED_HOUR] = obj.InstalledHour,
                [Parameters.FIRST_OPEN_HOUR] = obj.FirstOpenHour,
                [Parameters.INSTALL_BEGIN_TIME] = obj.InstallBeginTime,
                [Parameters.INSTALL_FINISH_TIME] = obj.InstallFinishTime,
                [Parameters.CREATED_TIME] = obj.CreatedTime,
                [Parameters.CREATED_TIME_MILLI] = obj.CreatedTimeMilli,
                [Parameters.CREATED_TIME_HOUR] = obj.CreatedTimeHour,

                [Parameters.LAST_SESSION_TIME] = obj.LastSessionTime,
                [Parameters.CONNECTION_TYPE] = obj.ConnectionType,
                [Parameters.CPU_TYPE] = obj.CpuType,
                [Parameters.HARDWARE_NAME] = obj.HardwareName,
                [Parameters.NETWORK_TYPE] = obj.NetworkType,
                [Parameters.DEVICE_MANUFACTURER] = obj.DeviceManufacturer,
                [Parameters.DEEPLINK_CLICK] = obj.DeeplinkClick,
                [Parameters.AFFISE_DEVICE_ID] = obj.AffDeviceId,
                [Parameters.AFFISE_ALT_DEVICE_ID] = obj.AffAltDeviceId,
                [Parameters.ANDROID_ID] = obj.AndroidId,
                [Parameters.GAID_ADID] = obj.GaidAdid,
                [Parameters.GAID_ADID_MD5] = obj.GaidAdidMd5,
                [Parameters.REFTOKEN] = obj.Reftoken,
                [Parameters.REFERRER] = obj.Referrer,
                [Parameters.USER_AGENT] = obj.UserAgent,
                [Parameters.ISP] = obj.Isp,
                [Parameters.LANGUAGE] = obj.Language,
                [Parameters.DEVICE_NAME] = obj.DeviceName,
                [Parameters.DEVICE_TYPE] = obj.DeviceType,
                [Parameters.OS_NAME] = obj.OsName,
                [Parameters.PLATFORM] = obj.Platform,
                [Parameters.API_LEVEL_OS] = obj.APILevelOs,
                [Parameters.AFFISE_SDK_VERSION] = obj.AffSdkVersion,
                [Parameters.OS_VERSION] = obj.OSVersion,
                [Parameters.RANDOM_USER_ID] = obj.RandomUserId,
                [Parameters.AFFISE_SDK_POS] = obj.AffSdkPos,
                [Parameters.TIMEZONE_DEV] = obj.TimezoneDev,
                [Parameters.AFFISE_APP_TOKEN] = obj.AffAppToken,
                [Parameters.LAST_TIME_SESSION] = obj.LastTimeSession,
                [Parameters.TIME_SESSION] = obj.TimeSession,
                [Parameters.AFFISE_SESSION_COUNT] = obj.AffSessionCount,
                [Parameters.LIFETIME_SESSION_COUNT] = obj.LifetimeSessionCount,
                [Parameters.AFFISE_DEEPLINK] = obj.AffDeeplink,
                [Parameters.AFFISE_PART_PARAM_NAME] = obj.AffPartParamName,
                [Parameters.AFFISE_PART_PARAM_NAME_TOKEN] = obj.AffPartParamNameToken,
                [Parameters.AFFISE_SDK_SECRET_ID] = obj.AffsdkSecretId,
                [Parameters.UUID] = obj.Uuid,
                // [Parameters.AFFISE_APP_OPENED] = obj.AffAppOpened,
                [Parameters.PUSHTOKEN] = obj.Pushtoken,

                [Parameters.AFFISE_EVENTS_COUNT] = eventsArray.Count,
                [EVENTS_KEY] = eventsArray,
                [Parameters.AFFISE_SDK_EVENTS_COUNT] = logsArray.Count,
                [SDK_EVENTS_KEY] = logsArray,
            };
        }
    }
}