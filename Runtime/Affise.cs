using System.Collections.Generic;
using AffiseAttributionLib.Events;
using AffiseAttributionLib.Init;
using AffiseAttributionLib.AffiseParameters;
using AffiseAttributionLib.Deeplink;
using AffiseAttributionLib.Referrer;
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR 
using AffiseAttributionLib.Native;
#endif
using UnityEngine;

namespace AffiseAttributionLib
{
    public static class Affise
    {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR 
        private static IAffiseNative _native;
#else   
        private static AffiseComponent _api;
#endif 

        public static bool IsInit  {
            get
            {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR 
                return _native is not null;
#else            
                return _api is not null;
#endif 
            }
        }

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

        /**
         * Send events
         */
        public static void SendEvents()
        {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR  
            _native.SendEvents();
#else
            _api.EventsManager.SendEvents();
#endif
        }

        /**
         * Store and send [event]
         */
        public static void SendEvent(AffiseEvent affiseEvent)
        {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR  
            _native.StoreEvent(affiseEvent);
#else
            _api.StoreEventUseCase.StoreEvent(affiseEvent);
#endif
        }
        
        /**
         * Add [pushToken]
         */
        public static void AddPushToken(string pushToken)
        {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR 
            _native.AddPushToken(pushToken);
#else
            PlayerPrefs.SetString(PushTokenProvider.KEY_APP_PUSHTOKEN, pushToken);
#endif
        }

        /**
         * Register [callback] for deeplink
         */
        public static void RegisterDeeplinkCallback(DeeplinkCallback callback)
        {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR 
            _native.RegisterDeeplinkCallback(callback);
#else
            _api?.DeeplinkManager?.SetDeeplinkCallback(callback);
#endif
        }
        
        /**
         * Set [pushToken]
         */
        public static void SetSecretId(string secretId)
        {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR 
            _native.SetSecretId(secretId);
#endif
        }
        
        /**
         * Set offline mode to [enabled] state
         */
        public static void SetOfflineModeEnabled(bool enabled)
        {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR 
            _native.SetOfflineModeEnabled(enabled);
#endif
        }
        
        /**
         * Return current offline mode state
         */
        public static bool? IsOfflineModeEnabled()
        {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR 
            return _native.IsOfflineModeEnabled();
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
            _native.SetBackgroundTrackingEnabled(enabled);
#endif
        }
        
        /**
         * Return current background tracking state
         */
        public static bool? IsBackgroundTrackingEnabled()
        {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR 
            return _native.IsBackgroundTrackingEnabled();
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
            _native.SetTrackingEnabled(enabled);
#endif
        }
        
        /**
         * Return current tracking state
         */
        public static bool? IsTrackingEnabled()
        {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR 
            return _native.IsTrackingEnabled();
#else
            return null;
#endif
        }

        public static class Android
        {
            /**
             * Send enabled autoCatching [types]
             */
            public static void SetAutoCatchingTypes(List<AutoCatchingType> types)
            {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR 
                _native.SetAutoCatchingTypes(types);
#endif
            }
            
            /**
             * Erases all user data
             */
            public static void Forget(string userData)
            {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR 
                _native.Forget(userData);
#endif
            }
        
            /**
             * Set [enabled] to collect metrics
             */
            public static void SetEnabledMetrics(bool enabled)
            {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR 
                _native.SetEnabledMetrics(enabled);
#endif
            }
            
            public static void CrashApplication()
            {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR 
                _native.CrashApplication();
#endif
            }
            
            /**
             * Get referrer
             */
            public static void GetReferrer(ReferrerCallback callback)
            {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR 
                _native.GetReferrer(callback);
#else
                callback.Invoke(_api?.InstallReferrerProvider?.Provide());
#endif
            }
            
            /**
             * Get referrer value by key
             */
            public static void GetReferrerValue(ReferrerKey key, ReferrerCallback callback)
            {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR 
                _native.GetReferrerValue(key, callback);
#else
                callback.Invoke(_api?.InstallReferrerProvider?.Provide());
#endif
            }
        }
    }
}