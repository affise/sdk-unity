using AffiseAttributionLib.Events;
using AffiseAttributionLib.Init;
using AffiseAttributionLib.AffiseParameters;
using AffiseAttributionLib.Deeplink;
using UnityEngine;

namespace AffiseAttributionLib
{
    public static class Affise
    {
        private static AffiseComponent _api;

        public static bool IsInit => _api is not null;

        public static void Init(AffiseInitProperties initProperties)
        {
            if (_api is not null) return;
            _api = new AffiseComponent(initProperties);
        }

        /**
         * Send events
         */
        public static void SendEvents()
        {
            _api.EventsManager.SendEvents();
        }

        /**
         * Store and send [event]
         */
        public static void SendEvent(AffiseEvent affiseEvent)
        {
            _api.StoreEventUseCase.StoreEvent(affiseEvent);
        }
        
        /**
         * Add [pushToken]
         */
        public static void AddPushToken(string pushToken)
        {
            PlayerPrefs.SetString(PushTokenProvider.KEY_APP_PUSHTOKEN, pushToken);
        }

        /**
         * Register [callback] for deeplink
         */
        public static void RegisterDeeplinkCallback(IOnDeeplinkCallback callback)
        {
            _api?.DeeplinkManager?.SetDeeplinkCallback(callback);
        }

        /**
         * Get referrer
         */
        public static string GetReferrer()
        {
            return _api?.InstallReferrerProvider?.Provide();
        }
    }
}