using AffiseAttributionLib.Events;
using AffiseAttributionLib.Init;
using AffiseAttributionLib.AffiseParameters;
using AffiseAttributionLib.Deeplink;
using AffiseAttributionLib.Referrer;
#if UNITY_ANDROID
using AffiseAttributionLib.Native.Android;
#endif 
using UnityEngine;

namespace AffiseAttributionLib
{
    public static class Affise
    {
#if UNITY_ANDROID && !UNITY_EDITOR 
        private static AffiseAndroidNative _nativeModules;
#else
        private static AffiseComponent _api;
#endif
        public static bool IsInit  {
            get
            {
#if UNITY_ANDROID && !UNITY_EDITOR 
                return _nativeModules is not null;
#else            
                return _api is not null;
#endif 
            }
        }

        public static void Init(AffiseInitProperties initProperties)
        {
#if UNITY_ANDROID && !UNITY_EDITOR  
            if (_nativeModules is not null) return;
            _nativeModules = new AffiseAndroidNative();
            _nativeModules.Init(initProperties);
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
#if UNITY_ANDROID && !UNITY_EDITOR  
            _nativeModules.SendEvents();
#else
            _api.EventsManager.SendEvents();
#endif
        }

        /**
         * Store and send [event]
         */
        public static void SendEvent(AffiseEvent affiseEvent)
        {
#if UNITY_ANDROID && !UNITY_EDITOR  
            _nativeModules.StoreEvent(affiseEvent);
#else
            _api.StoreEventUseCase.StoreEvent(affiseEvent);
#endif
        }
        
        /**
         * Add [pushToken]
         */
        public static void AddPushToken(string pushToken)
        {
#if UNITY_ANDROID && !UNITY_EDITOR 
            _nativeModules.AddPushToken(pushToken);
#else
            PlayerPrefs.SetString(PushTokenProvider.KEY_APP_PUSHTOKEN, pushToken);
#endif
        }

        /**
         * Register [callback] for deeplink
         */
        public static void RegisterDeeplinkCallback(DeeplinkCallback callback)
        {
#if UNITY_ANDROID && !UNITY_EDITOR 
            _nativeModules.RegisterDeeplinkCallback(callback);
#else
            _api?.DeeplinkManager?.SetDeeplinkCallback(callback);
#endif
        }

        public static class Android
        {
            /**
             * Get referrer
             */
            public static void GetReferrer(ReferrerCallback callback)
            {
#if UNITY_ANDROID && !UNITY_EDITOR 
                _nativeModules.GetReferrer(callback);
#else
                callback.Invoke(_api?.InstallReferrerProvider?.Provide());
#endif
            }
        }
    }
}