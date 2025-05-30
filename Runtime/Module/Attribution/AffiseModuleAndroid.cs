#nullable enable
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
using AffiseAttributionLib.Native;
#endif


namespace AffiseAttributionLib.Module.Attribution
{
    internal class AffiseModuleAndroid : IAffiseAndroidApi
    {
#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_EDITOR
        private IAffiseNative? _native => Affise._native;
#endif
        /**
         * Send enabled autoCatching [types]
         */
//         public void SetAutoCatchingTypes(List<AutoCatchingType> types)
//         {
// #if (UNITY_ANDROID) && !UNITY_EDITOR
//             _native?.SetAutoCatchingTypes(types);
// #else
//             UnityEngine.Debug.LogWarning($"{IAffiseAttributionModuleApi.NotSupported} - SetAutoCatchingTypes");
// #endif
//         }

        /**
         * Erases all user data
         */
        public void Forget(string userData)
        {
#if (UNITY_ANDROID) && !UNITY_EDITOR
            _native?.Forget(userData);
#else
            UnityEngine.Debug.LogWarning($"{IAffiseAttributionModuleApi.NotSupported} - Forget");
#endif
        }

        /**
             * Set [enabled] to collect metrics
             */
//         public void SetEnabledMetrics(bool enabled)
//         {
// #if (UNITY_ANDROID) && !UNITY_EDITOR
//             _native?.SetEnabledMetrics(enabled);
// #else
//             UnityEngine.Debug.LogWarning($"{IAffiseAttributionModuleApi.NotSupported} - SetEnabledMetrics");
// #endif
//         }

        public void CrashApplication()
        {
#if (UNITY_ANDROID) && !UNITY_EDITOR
            _native?.CrashApplication();
#else
            UnityEngine.Debug.LogWarning($"{IAffiseAttributionModuleApi.NotSupported} - CrashApplication");
#endif
        }
    }
}