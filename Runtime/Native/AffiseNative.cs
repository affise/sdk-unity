#nullable enable
using System;
using System.Collections.Generic;
using AffiseAttributionLib.AffiseParameters;
using AffiseAttributionLib.Converter;
using AffiseAttributionLib.Debugger.Network;
using AffiseAttributionLib.Debugger.Validate;
using AffiseAttributionLib.Deeplink;
using AffiseAttributionLib.Events;
using AffiseAttributionLib.Init;
using AffiseAttributionLib.Modules;
using AffiseAttributionLib.Native.Utils;
using AffiseAttributionLib.Referrer;
using AffiseAttributionLib.SKAd;
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

        public bool IsInitialized()
        {
            return Native<bool>(AffiseApiMethod.IS_INITIALIZED);
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
            NativeCallbackOnce(AffiseApiMethod.REGISTER_DEEPLINK_CALLBACK, callback: callback);
        }

        public void SetSecretKey(string secretKey)
        {
            Native(AffiseApiMethod.SET_SECRET_KEY, secretKey);
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
            NativeCallbackOnce(AffiseApiMethod.GET_REFERRER_CALLBACK, callback: callback);
        }

        public void GetReferrerValue(ReferrerKey key, ReferrerCallback callback)
        {
            NativeCallbackOnce(AffiseApiMethod.GET_REFERRER_VALUE_CALLBACK, callback: callback, data: key.ToValue());
        }

        public void GetStatus(AffiseModules module, OnKeyValueCallback callback)
        {
            NativeCallbackOnce(AffiseApiMethod.GET_STATUS_CALLBACK, callback: callback, data: module.Module());
        }

        public string? GetRandomUserId()
        {
            return Native<string>(AffiseApiMethod.GET_RANDOM_USER_ID);
        }

        public string? GetRandomDeviceId()
        {
            return Native<string>(AffiseApiMethod.GET_RANDOM_DEVICE_ID);
        }

        public Dictionary<ProviderType, object?> GetProviders()
        {
            return NativeMap(AffiseApiMethod.GET_PROVIDERS).ToProviderMap();
        }

        public void RegisterAppForAdNetworkAttribution(ErrorCallback completionHandler)
        {
            NativeCallbackOnce(AffiseApiMethod.SKAD_REGISTER_ERROR_CALLBACK, callback: completionHandler); 
        }

        public void UpdatePostbackConversionValue(int fineValue, CoarseValue coarseValue, ErrorCallback completionHandler)
        {
            var data = new Dictionary<string, object>
            {
                { "fineValue", fineValue },
                { "coarseValue", coarseValue.Value }
            };
            NativeCallbackOnce(AffiseApiMethod.SKAD_POSTBACK_ERROR_CALLBACK, callback: completionHandler, data: data);
        }

        public void Validate(DebugOnValidateCallback callback)
        {
            NativeCallbackOnce(AffiseApiMethod.DEBUG_VALIDATE_CALLBACK, callback: callback);
        }

        public void Network(DebugOnNetworkCallback callback)
        {
            NativeCallback(AffiseApiMethod.DEBUG_NETWORK_CALLBACK, callback: callback);
        }

        protected override void HandleCallback(AffiseApiMethod api, object callback, JSONNode? json)
        {
            switch (api)
            {
                case AffiseApiMethod.REGISTER_DEEPLINK_CALLBACK:
                    (callback as DeeplinkCallback)?.Invoke(new Uri(json?.Value ?? ""));
                    break;
                case AffiseApiMethod.GET_REFERRER_CALLBACK:
                    (callback as ReferrerCallback)?.Invoke(json?.Value);
                    break;
                case AffiseApiMethod.GET_REFERRER_VALUE_CALLBACK:
                    (callback as ReferrerCallback)?.Invoke(json?.Value);
                    break;
                case AffiseApiMethod.GET_STATUS_CALLBACK:
                    var values = json?.ToAffiseKeyValueList() ?? new List<AffiseKeyValue>();
                    (callback as OnKeyValueCallback)?.Invoke(values);
                    break;
                case AffiseApiMethod.SKAD_REGISTER_ERROR_CALLBACK:
                    (callback as ErrorCallback)?.Invoke(json?.Value);
                    break;
                case AffiseApiMethod.SKAD_POSTBACK_ERROR_CALLBACK:
                    (callback as ErrorCallback)?.Invoke(json?.Value);
                    break;
                case AffiseApiMethod.DEBUG_VALIDATE_CALLBACK:
                    var status = DebugUtils.GetValidationStatus(json?.Value);
                    (callback as DebugOnValidateCallback)?.Invoke(status);
                    break;
                case AffiseApiMethod.DEBUG_NETWORK_CALLBACK:
                    var (request, response) = DebugUtils.ParseRequestResponse(json?.AsObject);
                    (callback as DebugOnNetworkCallback)?.Invoke(request, response);
                    break;
            }
        }
    }
}