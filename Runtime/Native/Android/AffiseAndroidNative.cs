using System;
using System.Collections.Generic;
using AffiseAttributionLib.Deeplink;
using AffiseAttributionLib.Events;
using AffiseAttributionLib.Init;
using SimpleJSON;

namespace AffiseAttributionLib.Native.Android
{
    internal class AffiseAndroidNative : AndroidNativeModules
    {
        private const string JavaNativeModules = "com.affise.attribution.unity.AffiseNativeModules";

        private const string AFFISE_INIT = "init";
        private const string AFFISE_SEND_EVENTS = "send_events";
        private const string AFFISE_SEND_EVENT = "send_event";
        private const string AFFISE_ADD_PUSH_TOKEN = "add_push_token";
        private const string AFFISE_REGISTER_DEEPLINK_CALLBACK = "register_deeplink_callback";
        private const string AFFISE_SET_SECRET_ID = "set_secret_id";
        private const string AFFISE_SET_AUTO_CATCHING_TYPES = "set_auto_catching_types";
        private const string AFFISE_SET_OFFLINE_MODE_ENABLED = "set_offline_mode_enabled";
        private const string AFFISE_IS_OFFLINE_MODE_ENABLED = "is_offline_mode_enabled";
        private const string AFFISE_SET_BACKGROUND_TRACKING_ENABLED = "set_background_tracking_enabled";
        private const string AFFISE_IS_BACKGROUND_TRACKING_ENABLED = "is_background_tracking_enabled";
        private const string AFFISE_SET_TRACKING_ENABLED = "set_tracking_enabled";
        private const string AFFISE_IS_TRACKING_ENABLED = "is_tracking_enabled";
        private const string AFFISE_FORGET = "forget";
        private const string AFFISE_SET_ENABLED_METRICS = "set_enabled_metrics";
        private const string AFFISE_CRASH_APPLICATION = "crash_application";
        private const string AFFISE_GET_REFERRER = "get_referrer";

        private const string NATIVE_DEEPLINK_CALLBACK = "native_deeplink_callback";

        private DeeplinkCallback _onDeeplinkCallback;

        public AffiseAndroidNative() : base(JavaNativeModules)
        {
        }

        public void Init(AffiseInitProperties initProperties)
        {
            InvokeMethod(AFFISE_INIT, initProperties.ToJson.ToString());
        }

        public void SendEvents()
        {
            InvokeMethod(AFFISE_SEND_EVENTS);
        }

        public void StoreEvent(AffiseEvent affiseEvent)
        {
            InvokeMethod(AFFISE_SEND_EVENT, affiseEvent.ToJson.ToString());
        }

        public void AddPushToken(string pushToken)
        {
            var json = new JSONObject { [AFFISE_ADD_PUSH_TOKEN] = pushToken };
            InvokeMethod(AFFISE_ADD_PUSH_TOKEN, json.ToString());
        }

        public void RegisterDeeplinkCallback(DeeplinkCallback callback)
        {
            _onDeeplinkCallback = callback;
            InvokeMethod(AFFISE_REGISTER_DEEPLINK_CALLBACK);
        }

        public void SetSecretId(string secretId)
        {
            var json = new JSONObject { [AFFISE_SET_SECRET_ID] = secretId };
            InvokeMethod(AFFISE_SET_SECRET_ID, json.ToString());
        }

        public void SetAutoCatchingTypes(List<string> types)
        {
            var arrType = new JSONArray();
            foreach (var type in types)
            {
                arrType.Add(type);
            }

            var json = new JSONObject { [AFFISE_SET_AUTO_CATCHING_TYPES] = arrType };
            InvokeMethod(AFFISE_SET_AUTO_CATCHING_TYPES, json.ToString());
        }

        public void SetOfflineModeEnabled(bool enabled)
        {
            var json = new JSONObject { [AFFISE_SET_OFFLINE_MODE_ENABLED] = enabled };
            InvokeMethod(AFFISE_SET_OFFLINE_MODE_ENABLED, json.ToString());
        }

        public bool IsOfflineModeEnabled()
        {
            return InvokeMethod<bool>(AFFISE_IS_OFFLINE_MODE_ENABLED);
        }

        public void SetBackgroundTrackingEnabled(bool enabled)
        {
            var json = new JSONObject { [AFFISE_SET_BACKGROUND_TRACKING_ENABLED] = enabled };
            InvokeMethod(AFFISE_SET_BACKGROUND_TRACKING_ENABLED, json.ToString());
        }

        public bool IsBackgroundTrackingEnabled()
        {
            return InvokeMethod<bool>(AFFISE_IS_BACKGROUND_TRACKING_ENABLED);
        }

        public void SetTrackingEnabled(bool enabled)
        {
            var json = new JSONObject { [AFFISE_SET_TRACKING_ENABLED] = enabled };
            InvokeMethod(AFFISE_SET_TRACKING_ENABLED, json.ToString());
        }

        public bool IsTrackingEnabled()
        {
            return InvokeMethod<bool>(AFFISE_IS_TRACKING_ENABLED);
        }

        public void Forget(string userData)
        {
            var json = new JSONObject { [AFFISE_FORGET] = userData };
            InvokeMethod(AFFISE_FORGET, json.ToString());
        }

        public void SetEnabledMetrics(bool enabled)
        {
            var json = new JSONObject { [AFFISE_SET_ENABLED_METRICS] = enabled };
            InvokeMethod(AFFISE_SET_ENABLED_METRICS, json.ToString());
        }

        public void CrashApplication()
        {
            InvokeMethod(AFFISE_CRASH_APPLICATION);
        }

        public string GetReferrer()
        {
            return InvokeMethod<string>(AFFISE_GET_REFERRER);
        }

        protected override bool HandleEvent(string eventName, string data)
        {
            return eventName switch
            {
                NATIVE_DEEPLINK_CALLBACK => _onDeeplinkCallback?.Invoke(new Uri(data)) ?? false,
                _ => false
            };
        }
    }
}