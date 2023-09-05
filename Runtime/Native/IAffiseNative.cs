#nullable enable
using System.Collections.Generic;
using AffiseAttributionLib.Deeplink;
using AffiseAttributionLib.Events;
using AffiseAttributionLib.Init;
using AffiseAttributionLib.Modules;
using AffiseAttributionLib.Referrer;
using AffiseAttributionLib.SKAd;

namespace AffiseAttributionLib.Native
{
    internal interface IAffiseNative
    {
        void Init(AffiseInitProperties initProperties);
        
        bool IsInitialized();
        
        void SendEvents();

        void SendEvent(AffiseEvent affiseEvent);

        void AddPushToken(string pushToken);

        void RegisterDeeplinkCallback(DeeplinkCallback callback);

        void SetSecretKey(string secretKey);

        void SetAutoCatchingTypes(List<AutoCatchingType> types);

        void SetOfflineModeEnabled(bool enabled);

        bool IsOfflineModeEnabled();

        void SetBackgroundTrackingEnabled(bool enabled);

        bool IsBackgroundTrackingEnabled();

        void SetTrackingEnabled(bool enabled);

        bool IsTrackingEnabled();

        void Forget(string userData);

        void SetEnabledMetrics(bool enabled);

        void CrashApplication();

        void GetReferrer(ReferrerCallback callback);

        void GetReferrerValue(ReferrerKey key, ReferrerCallback callback);
        
        void GetStatus(AffiseModules module, OnKeyValueCallback callback);

        string? GetRandomUserId();

        string? GetRandomDeviceId();

        void RegisterAppForAdNetworkAttribution(ErrorCallback completionHandler);
        
        void UpdatePostbackConversionValue(int fineValue, CoarseValue coarseValue, ErrorCallback completionHandler);
    }
}