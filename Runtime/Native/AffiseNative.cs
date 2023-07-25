#nullable enable
using System;
using System.Collections.Generic;
using AffiseAttributionLib.Converter;
using AffiseAttributionLib.Deeplink;
using AffiseAttributionLib.Events;
using AffiseAttributionLib.Init;
using AffiseAttributionLib.Modules;
using AffiseAttributionLib.Referrer;
using SimpleJSON;

namespace AffiseAttributionLib.Native
{
    internal class AffiseNative : NativeBase, IAffiseNative
    {
        private readonly EventToSerializedEventConverter _converter = new();

        public AffiseNative(AffiseInitProperties initProperties)
        {
            Init(initProperties);
        }

        public void Init(AffiseInitProperties initProperties)
        {
            Native(AffiseApiMethod.INIT, initProperties.ToJson);
        }

        public void SendEvents()
        {
            Native(AffiseApiMethod.SEND_EVENTS);
        }

        public void SendEvent(AffiseEvent affiseEvent)
        {
            var data = _converter.Convert(affiseEvent).Data;
            Native(AffiseApiMethod.SEND_EVENT, data);
        }

        public void AddPushToken(string pushToken)
        {
            Native(AffiseApiMethod.ADD_PUSH_TOKEN, pushToken);
        }

        public void RegisterDeeplinkCallback(DeeplinkCallback callback)
        {
            NativeCallback(AffiseApiMethod.REGISTER_DEEPLINK_CALLBACK, callback: callback);
        }

        public void SetSecretId(string secretId)
        {
            Native(AffiseApiMethod.SET_SECRET_ID, secretId);
        }

        public void SetAutoCatchingTypes(List<AutoCatchingType> types)
        {
            Native(AffiseApiMethod.SET_AUTO_CATCHING_TYPES, types.ToJsonArray());
        }

        public void SetOfflineModeEnabled(bool enabled)
        {
            Native(AffiseApiMethod.SET_OFFLINE_MODE_ENABLED, enabled);
        }

        public bool IsOfflineModeEnabled()
        {
            return Native<bool>(AffiseApiMethod.IS_OFFLINE_MODE_ENABLED);
        }

        public void SetBackgroundTrackingEnabled(bool enabled)
        {
            Native(AffiseApiMethod.SET_BACKGROUND_TRACKING_ENABLED, enabled);
        }

        public bool IsBackgroundTrackingEnabled()
        {
            return Native<bool>(AffiseApiMethod.IS_BACKGROUND_TRACKING_ENABLED);
        }

        public void SetTrackingEnabled(bool enabled)
        {
            Native(AffiseApiMethod.SET_TRACKING_ENABLED, enabled);
        }

        public bool IsTrackingEnabled()
        {
            return Native<bool>(AffiseApiMethod.IS_TRACKING_ENABLED);
        }

        public void Forget(string userData)
        {
            Native(AffiseApiMethod.FORGET, userData);
        }

        public void SetEnabledMetrics(bool enabled)
        {
            Native(AffiseApiMethod.SET_ENABLED_METRICS, enabled);
        }

        public void CrashApplication()
        {
            Native(AffiseApiMethod.CRASH_APPLICATION);
        }

        public void GetReferrer(ReferrerCallback callback)
        {
            NativeCallback(AffiseApiMethod.GET_REFERRER_CALLBACK, callback: callback);
        }

        public void GetReferrerValue(ReferrerKey key, ReferrerCallback callback)
        {
            NativeCallback(AffiseApiMethod.GET_REFERRER_VALUE_CALLBACK, callback: callback, data: key.ToValue());
        }

        public void GetStatus(AffiseModules module, OnKeyValueCallback callback)
        {
            NativeCallback(AffiseApiMethod.GET_STATUS_CALLBACK, callback: callback, data: module.ToValue());
        }

        public string? GetRandomUserId()
        {
            return Native<string>(AffiseApiMethod.GET_RANDOM_USER_ID);
        }

        public string? GetRandomDeviceId()
        {
            return Native<string>(AffiseApiMethod.GET_RANDOM_DEVICE_ID);
        }

        protected override void HandleCallback(AffiseApiMethod? api, object callback, JSONNode? json)
        {
            switch (api)
            {
                case AffiseApiMethod.REGISTER_DEEPLINK_CALLBACK:
                    (callback as DeeplinkCallback)?.Invoke(new Uri(json?.ToString() ?? ""));
                    break;
                case AffiseApiMethod.GET_REFERRER_CALLBACK:
                    (callback as ReferrerCallback)?.Invoke(json?.ToString());
                    break;
                case AffiseApiMethod.GET_REFERRER_VALUE_CALLBACK:
                    (callback as ReferrerCallback)?.Invoke(json?.ToString());
                    break;
                case AffiseApiMethod.GET_STATUS_CALLBACK:
                    var values = json?.ToAffiseKeyValueList() ?? new List<AffiseKeyValue>();
                    (callback as OnKeyValueCallback)?.Invoke(values);
                    break;
            }
        }
    }
}