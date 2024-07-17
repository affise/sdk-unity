#nullable enable
using System.Collections.Generic;
using AffiseAttributionLib.AffiseParameters;
using AffiseAttributionLib.Converter;
using AffiseAttributionLib.Debugger.Network;
using AffiseAttributionLib.Debugger.Validate;
using AffiseAttributionLib.Deeplink;
using AffiseAttributionLib.Events;
using AffiseAttributionLib.Init;
using AffiseAttributionLib.Module.Link;
using AffiseAttributionLib.Modules;
using AffiseAttributionLib.Native.Utils;
using AffiseAttributionLib.Referrer;
using AffiseAttributionLib.SKAd;
using SimpleJSON;

namespace AffiseAttributionLib.Native
{
    internal class AffiseNative : NativeBase, IAffiseNative
    {
        private const string SUCCESS = "success";
        private const string FAILED = "failed";

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

        public void SendEvent(AffiseEvent affiseEvent)
        {
            var data = _converter.Convert(affiseEvent).Data;
            Native(AffiseApiMethod.SEND_EVENT, data);
        }

        public void SendEventNow(AffiseEvent affiseEvent, OnSendSuccessCallback success, OnSendFailedCallback failed)
        {
            var data = _converter.Convert(affiseEvent).Data;
            NativeCallbackGroup(
                AffiseApiMethod.SEND_EVENT_NOW,
                new Dictionary<string, object>()
                {
                    { SUCCESS, success },
                    { FAILED, failed }
                },
                data
            );
        }

        public void AddPushToken(string pushToken)
        {
            Native(AffiseApiMethod.ADD_PUSH_TOKEN, pushToken);
        }

        public void RegisterDeeplinkCallback(DeeplinkCallback callback)
        {
            NativeCallback(AffiseApiMethod.REGISTER_DEEPLINK_CALLBACK, callback: callback);
            InitialLink();
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

        public bool IsFirstRun()
        {
            return Native<bool>(AffiseApiMethod.IS_FIRST_RUN);
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

        public void UpdatePostbackConversionValue(
            int fineValue,
            CoarseValue coarseValue,
            ErrorCallback completionHandler
        )
        {
            var data = new Dictionary<string, object>
            {
                { "fineValue", fineValue },
                { "coarseValue", coarseValue.Value }
            };
            NativeCallbackOnce(
                api: AffiseApiMethod.SKAD_POSTBACK_ERROR_CALLBACK,
                callback: completionHandler, 
                data: data
            );
        }

        public void Validate(DebugOnValidateCallback callback)
        {
            NativeCallbackOnce(AffiseApiMethod.DEBUG_VALIDATE_CALLBACK, callback: callback);
        }

        public void Network(DebugOnNetworkCallback callback)
        {
            NativeCallback(AffiseApiMethod.DEBUG_NETWORK_CALLBACK, callback: callback);
        }
        
        ////////////////////////////////////////
        // modules
        ////////////////////////////////////////
        public void GetStatus(AffiseModules module, OnKeyValueCallback callback)
        {
            NativeCallbackOnce(
                api: AffiseApiMethod.GET_STATUS_CALLBACK, 
                callback: callback, 
                data: module.Module()
            );
        }

        public bool ModuleStart(AffiseModules module)
        {
            return Native<bool>(AffiseApiMethod.MODULE_START, module.Module());
        }

        public List<AffiseModules> GetModules()
        {
            var result = new List<AffiseModules>();
            var data = NativeList(AffiseApiMethod.GET_MODULES_INSTALLED);
            if (data == null) return result;
            foreach (var (_, value) in data)
            {
                var module = AffiseModulesExt.From(value?.Value);
                if (module is null) continue;
                result.Add((AffiseModules)module);
            }

            return result;
        }

        public void LinkResolve(string uri, AffiseLinkCallback callback)
        {
            NativeCallbackOnce(
                api: AffiseApiMethod.MODULE_LINK_LINK_RESOLVE_CALLBACK,
                callback: callback,
                data: uri
            );
        }
        ////////////////////////////////////////
        // modules
        ////////////////////////////////////////

        protected override void HandleCallback(AffiseApiMethod api, object callback, JSONNode? json, string? tag)
        {
            switch (api)
            {
                case AffiseApiMethod.SEND_EVENT_NOW:
                    switch (tag)
                    {
                        case SUCCESS:
                            (callback as OnSendSuccessCallback)?.Invoke();
                            break;
                        case FAILED:
                            (callback as OnSendFailedCallback)?.Invoke(DebugUtils.ToResponse(json));
                            break;
                    }
                    break;
                case AffiseApiMethod.REGISTER_DEEPLINK_CALLBACK:
                    (callback as DeeplinkCallback)?.Invoke(DataMapper.ToDeeplinkValue(json));
                    break;
                case AffiseApiMethod.GET_REFERRER_CALLBACK:
                    (callback as ReferrerCallback)?.Invoke(DataMapper.ToNonNullString(json));
                    break;
                case AffiseApiMethod.GET_REFERRER_VALUE_CALLBACK:
                    (callback as ReferrerCallback)?.Invoke(DataMapper.ToNonNullString(json));
                    break;
                case AffiseApiMethod.SKAD_REGISTER_ERROR_CALLBACK:
                    (callback as ErrorCallback)?.Invoke(DataMapper.ToNonNullString(json));
                    break;
                case AffiseApiMethod.SKAD_POSTBACK_ERROR_CALLBACK:
                    (callback as ErrorCallback)?.Invoke(DataMapper.ToNonNullString(json));
                    break;
                case AffiseApiMethod.DEBUG_VALIDATE_CALLBACK:
                    (callback as DebugOnValidateCallback)?.Invoke(DebugUtils.GetValidationStatus(json));
                    break;
                case AffiseApiMethod.DEBUG_NETWORK_CALLBACK:
                    var (request, response) = DebugUtils.ParseRequestResponse(json);
                    (callback as DebugOnNetworkCallback)?.Invoke(request, response);
                    break;
                ////////////////////////////////////////
                // modules
                ////////////////////////////////////////
                case AffiseApiMethod.GET_STATUS_CALLBACK:
                    (callback as OnKeyValueCallback)?.Invoke(DataMapper.ToAffiseKeyValueList(json));
                    break;
                case AffiseApiMethod.MODULE_LINK_LINK_RESOLVE_CALLBACK:
                    (callback as AffiseLinkCallback)?.Invoke(DataMapper.ToNonNullString(json));
                    break;
                ////////////////////////////////////////
                // modules
                ////////////////////////////////////////
            }
        }
    }
}