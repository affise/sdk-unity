#nullable enable
using System;
using System.Collections.Generic;
using AffiseAttributionLib.AffiseParameters;
using AffiseAttributionLib.AffiseParameters.Providers;
using AffiseAttributionLib.Deeplink;
using AffiseAttributionLib.Events;
using AffiseAttributionLib.Init;
using AffiseAttributionLib.Modules;
using AffiseAttributionLib.Referrer;
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

        /**
         * Init [AffiseComponent] with [initProperties]
         */
        public static void Init(AffiseInitProperties initProperties)
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
         * Send events
         */
        public static void SendEvents()
        {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
            _native?.SendEvents();
#else
            _api?.EventsManager.SendEvents();
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
            _api?.DeeplinkManager?.SetDeeplinkCallback(callback);
#endif
        }

        /**
         * Set new SDK [secretKey]
         */
        [Obsolete("use SetSecretKey(secretKey)")]
        public static void SetSecretId(string secretId)
        {
            SetSecretKey(secretId);
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
        public static void GetStatus(AffiseModules module, OnKeyValueCallback onComplete)
        {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
            _native?.GetStatus(module, onComplete);
#else
            onComplete.Invoke(new List<AffiseKeyValue>
            {
                new("error", NotSupported)
            });
#endif
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
        
        public static class Android
        {
            /**
             * Send enabled autoCatching [types]
             */
            public static void SetAutoCatchingTypes(List<AutoCatchingType> types)
            {
#if (UNITY_ANDROID) && !UNITY_EDITOR
                _native?.SetAutoCatchingTypes(types);
#endif
            }

            /**
             * Erases all user data
             */
            public static void Forget(string userData)
            {
#if (UNITY_ANDROID) && !UNITY_EDITOR
                _native?.Forget(userData);
#endif
            }

            /**
             * Set [enabled] to collect metrics
             */
            public static void SetEnabledMetrics(bool enabled)
            {
#if (UNITY_ANDROID) && !UNITY_EDITOR
                _native?.SetEnabledMetrics(enabled);
#endif
            }

            public static void CrashApplication()
            {
#if (UNITY_ANDROID) && !UNITY_EDITOR
                _native?.CrashApplication();
#endif
            }

            /**
             * Get referrer
             */
            public static void GetReferrer(ReferrerCallback callback)
            {
#if (UNITY_ANDROID) && !UNITY_EDITOR
                _native?.GetReferrer(callback);
#else
                callback.Invoke(NotSupported);
#endif
            }

            /**
             * Get referrer value by key
             */
            public static void GetReferrerValue(ReferrerKey key, ReferrerCallback callback)
            {
#if (UNITY_ANDROID) && !UNITY_EDITOR
                _native?.GetReferrerValue(key, callback);
#else
                callback.Invoke(NotSupported);
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
        }

        private static string NotSupported = "[Affise] platform not supported";
    }
}