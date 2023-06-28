using System.Collections.Generic;
using AffiseAttributionLib.Deeplink;
using AffiseAttributionLib.Events;
using AffiseAttributionLib.Init;
using AffiseAttributionLib.Referrer;

namespace AffiseAttributionLib.Native
{
    internal interface IAffiseNative
    {
        void Init(AffiseInitProperties initProperties);

        void SendEvents();

        void StoreEvent(AffiseEvent affiseEvent);

        void AddPushToken(string pushToken);

        void RegisterDeeplinkCallback(DeeplinkCallback callback);

        void SetSecretId(string secretId);

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
    }
}