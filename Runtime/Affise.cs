#nullable enable
using System;
using System.Collections.Generic;
using AffiseAttributionLib.AffiseParameters;
using AffiseAttributionLib.AffiseParameters.Providers;
using AffiseAttributionLib.Debugger.Network;
using AffiseAttributionLib.Debugger.Validate;
using AffiseAttributionLib.Deeplink;
using AffiseAttributionLib.Events;
using AffiseAttributionLib.Init;
using AffiseAttributionLib.Module;
using AffiseAttributionLib.Module.Link;
using AffiseAttributionLib.Module.Subscription;
using AffiseAttributionLib.Modules;
using AffiseAttributionLib.Referrer;
using AffiseAttributionLib.Settings;
using AffiseAttributionLib.SKAd;
using AffiseAttributionLib.Utils;
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
using AffiseAttributionLib.Native;
#endif

namespace AffiseAttributionLib
{
    public static class Affise
    {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
        private static IAffiseNative? _native;
#else
        private static AffiseComponent? _api;
#endif

        internal static bool IsInit
        {
            get
            {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
                return _native is not null;
#else
                return _api is not null;
#endif
            }
        }

        public static AffiseSettings Settings(string affiseAppId, string secretKey)
        {
            return new AffiseSettings(affiseAppId, secretKey);
        }

        internal static void Start(AffiseInitProperties initProperties)
        {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
            if (_native is not null) return;
            _native = new AffiseNative(initProperties);
#else
            if (_api is not null) return;
            _api = new AffiseComponent(initProperties);
#endif
        }

        public static bool IsInitialized()
        {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
            return _native?.IsInitialized() ?? false;
#else
            return _api?.IsInitialized() ?? false;
#endif
        }

        /**
         * Store and send [affiseEvent]
         */
        public static void SendEvent(AffiseEvent affiseEvent)
        {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
            _native?.SendEvent(affiseEvent);
#else
            _api?.StoreEventUseCase.StoreEvent(affiseEvent);
#endif
        }

        /**
         * Send [affiseEvent] now
         */
        public static void SendEventNow(AffiseEvent affiseEvent, OnSendSuccessCallback success, OnSendFailedCallback failed)
        {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
            _native?.SendEventNow(affiseEvent, success, failed);
#else
            _api?.ImmediateSendToServerUseCase.SendNow(affiseEvent, success, failed);
#endif
        }
        
        /**
         * Add [pushToken]
         */
        public static void AddPushToken(string pushToken)
        {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
            _native?.AddPushToken(pushToken);
#else
            PrefUtils.SaveString(PushTokenProvider.KEY_APP_PUSHTOKEN, pushToken);
#endif
        }

        /**
         * Register [callback] for deeplink
         */
        public static void RegisterDeeplinkCallback(DeeplinkCallback callback)
        {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
            _native?.RegisterDeeplinkCallback(callback);
#else
            _api?.DeeplinkManager.SetDeeplinkCallback(callback);
#endif
        }

        /**
         * Set new SDK [secretKey]
         */
        public static void SetSecretKey(string secretKey)
        {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
            _native?.SetSecretKey(secretKey);
#else
            _api?.InitPropertiesStorage?.UpdateSecretKey(secretKey);
#endif
        }

        /**
         * Set offline mode to [enabled] state
         */
        public static void SetOfflineModeEnabled(bool enabled)
        {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
            _native?.SetOfflineModeEnabled(enabled);
#endif
        }

        /**
         * Return current offline mode state
         */
        public static bool? IsOfflineModeEnabled()
        {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
            return _native?.IsOfflineModeEnabled();
#else
            return null;
#endif
        }

        /**
         * Set background tracking to [enabled] state
         */
        public static void SetBackgroundTrackingEnabled(bool enabled)
        {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
            _native?.SetBackgroundTrackingEnabled(enabled);
#endif
        }

        /**
         * Return current background tracking state
         */
        public static bool? IsBackgroundTrackingEnabled()
        {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
            return _native?.IsBackgroundTrackingEnabled();
#else
            return null;
#endif
        }

        /**
         * Set tracking to [enabled] state
         */
        public static void SetTrackingEnabled(bool enabled)
        {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
            _native?.SetTrackingEnabled(enabled);
#endif
        }

        /**
         * Return current tracking state
         */
        public static bool? IsTrackingEnabled()
        {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
            return _native?.IsTrackingEnabled();
#else
            return null;
#endif
        }

        /**
         * Get module status
         */
        [Obsolete("Affise.GetStatus is deprecated, please use Affise.Module.GetStatus instead.")]
        public static void GetStatus(AffiseModules module, OnKeyValueCallback onComplete)
        {
            Module.GetStatus(module, onComplete);
        }
        
        /**
         * Manual module start
         */
        [Obsolete("Affise.ModuleStart is deprecated, please use Affise.Module.ModuleStart instead.")]
        public static bool ModuleStart(AffiseModules module)
        {
            return Module.ModuleStart(module);
        }
        
        /**
         * Get installed modules
         */
        [Obsolete("Affise.GetModulesInstalled is deprecated, please use Affise.Module.GetModulesInstalled instead.")]
        public static List<AffiseModules> GetModulesInstalled()
        {
            return Module.GetModulesInstalled();
        }
        
        public static string? GetRandomUserId()
        {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
            return _native?.GetRandomUserId();
#else
            return _api?.PostBackModelFactory.GetProvider<RandomUserIdProvider>()?.Provide();
#endif
        }

        public static string? GetRandomDeviceId()
        {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
            return _native?.GetRandomDeviceId();
#else
            return _api?.PostBackModelFactory.GetProvider<AffiseDeviceIdProvider>()?.Provide();
#endif
        }

        public static Dictionary<ProviderType, object?> GetProviders()
        {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
            return _native?.GetProviders() ?? new Dictionary<ProviderType, object?>();
#else
            return _api?.PostBackModelFactory.GetProvidersMap() ?? new Dictionary<ProviderType, object?>();
#endif
        }
        
        public static bool IsFirstRun()
        {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
            return _native?.IsFirstRun() ?? true; 
#else
            return _api?.FirstAppOpenUseCase.IsFirstRun() ?? true;
#endif
        }
        
        /**
         * Get referrer
         */
        [Obsolete("Affise.GetReferrer is deprecated, please use Affise.GetReferrerUrl instead.")]
        public static void GetReferrer(ReferrerCallback callback)
        {
            GetReferrerUrl(callback);
        }

        /**
         * Get referrer value by key
         */
        [Obsolete("Affise.GetReferrerValue is deprecated, please use Affise.GetReferrerUrlValue instead.")]
        public static void GetReferrerValue(ReferrerKey key, ReferrerCallback callback)
        {
            GetReferrerUrlValue(key, callback);
        }

        /**
         * Get referrer url
         */
        public static void GetReferrerUrl(ReferrerCallback callback)
        {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
            _native?.GetReferrerUrl(callback);
#else
            callback.Invoke(NotSupported);
#endif
        }

        /**
         * Get referrer value by key
         */
        public static void GetReferrerUrlValue(ReferrerKey key, ReferrerCallback callback)
        {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
            _native?.GetReferrerUrlValue(key, callback);
#else
            callback.Invoke(NotSupported);
#endif
        }
        
        public static class Android
        {
            /**
             * Send enabled autoCatching [types]
             */
//             public static void SetAutoCatchingTypes(List<AutoCatchingType> types)
//             {
// #if (UNITY_ANDROID) && !UNITY_EDITOR
//                 _native?.SetAutoCatchingTypes(types);
// #else
//                 UnityEngine.Debug.LogWarning($"{NotSupported} - SetAutoCatchingTypes");
// #endif
//             }

            /**
             * Erases all user data
             */
            public static void Forget(string userData)
            {
#if (UNITY_ANDROID) && !UNITY_EDITOR
                _native?.Forget(userData);
#else
                UnityEngine.Debug.LogWarning($"{NotSupported} - Forget");
#endif
            }

            /**
             * Set [enabled] to collect metrics
             */
//             public static void SetEnabledMetrics(bool enabled)
//             {
// #if (UNITY_ANDROID) && !UNITY_EDITOR
//                 _native?.SetEnabledMetrics(enabled);
// #else
//                 UnityEngine.Debug.LogWarning($"{NotSupported} - SetEnabledMetrics");
// #endif
//             }

            public static void CrashApplication()
            {
#if (UNITY_ANDROID) && !UNITY_EDITOR
                _native?.CrashApplication();
#else
                UnityEngine.Debug.LogWarning($"{NotSupported} - CrashApplication");
#endif
            }
        }
        
        public static class IOS
        {
            /**
             * StoreKit Ad Network register app
             */
            public static void RegisterAppForAdNetworkAttribution(ErrorCallback completionHandler)
            {
#if (UNITY_IOS) && !UNITY_EDITOR
                _native?.RegisterAppForAdNetworkAttribution(completionHandler);
#else
                completionHandler.Invoke(NotSupported);
#endif
            }

            /**
             * StoreKit Ad Network updatePostbackConversionValue
             */
            public static void UpdatePostbackConversionValue(int fineValue, CoarseValue coarseValue, ErrorCallback completionHandler)
            {
#if (UNITY_IOS) && !UNITY_EDITOR
                _native?.UpdatePostbackConversionValue(fineValue, coarseValue, completionHandler);
#else
                completionHandler.Invoke(NotSupported);
#endif
            }
            
            /**
             * Get referrer url
             */
            public static void GetReferrerOnServer(ReferrerCallback callback)
            {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
                _native?.GetReferrerOnServer(callback);
#else
                callback.Invoke(NotSupported);
#endif
            }

            /**
             * Get referrer value by key
             */
            public static void GetReferrerOnServerValue(ReferrerKey key, ReferrerCallback callback)
            {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
                _native?.GetReferrerOnServerValue(key, callback);
#else
                callback.Invoke(NotSupported);
#endif
            }
        }

        public static class Module
        {
            /**
             * Get module status
             */
            public static void GetStatus(AffiseModules module, OnKeyValueCallback onComplete)
            {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
                _native?.GetStatus(module, onComplete);
#else
                _api?.ModuleManager.Status(module, onComplete);
#endif
            }

            /**
             * Manual module start
             */
            public static bool ModuleStart(AffiseModules module)
            {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
                return _native?.ModuleStart(module) ?? true;
#else
                return _api?.ModuleManager.ManualStart(module) ?? true;
#endif
            }
        
            /**
             * Get installed modules
             */
            public static List<AffiseModules> GetModulesInstalled()
            {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
                return _native?.GetModules() ?? new List<AffiseModules>();
#else
                return _api?.ModuleManager.GetModules() ?? new List<AffiseModules>();
#endif
            }
            
            /**
             * Module Link url Resolve
             */
            public static void LinkResolve(string uri, AffiseLinkCallback callback)
            {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
                _native?.LinkResolve(uri, callback);
#else
                Api<IAffiseLinkApi>(AffiseModules.Link)?.LinkResolve(uri, callback);
#endif
            }
            
            /**
             * Module Subscription fetch products
             */
            public static void FetchProducts(List<string> ids, AffiseResultCallback<AffiseProductsResult> callback)
            {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
                _native?.FetchProducts(ids, callback);           
#else
                UnityEngine.Debug.LogWarning($"{NotSupported} - FetchProducts");
                callback.Invoke(AffiseResult<AffiseProductsResult>.Failure(NotSupported));
#endif
            }
            
            /**
             * Module Subscription purchase
             */
            public static void Purchase(
                AffiseProduct product, 
                AffiseProductType type, 
                AffiseResultCallback<AffisePurchasedInfo> callback
            )
            {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
                _native?.Purchase(product, type, callback);
#else               
                UnityEngine.Debug.LogWarning($"{NotSupported} - Purchase");
                callback.Invoke(AffiseResult<AffisePurchasedInfo>.Failure(NotSupported));
#endif
            }
            
            private static T? Api<T>(AffiseModules module) where T : IAffiseModuleApi
            {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
                return default;
#else
                if ( _api?.ModuleManager.GetModule(module) is T result) return result;
                return default;
#endif
            }
        }

        public static class Debug
        {
            /**
             * Won't work on Production
             *
             * Validate credentials
             */
            public static void Validate(DebugOnValidateCallback callback)
            {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
                _native?.Validate(callback);
#else
                _api?.DebugValidateUseCase?.Validate(callback);
#endif
            }
            
            /**
             * Won't work on Production
             *
             * Show request/response data
             */
            public static void Network(DebugOnNetworkCallback callback)
            { 
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
                _native?.Network(callback);
#else
                _api?.DebugNetworkUseCase.OnRequest(callback);
#endif
            }
        }

        private const string NotSupported = "[Affise] platform not supported";
    }
}