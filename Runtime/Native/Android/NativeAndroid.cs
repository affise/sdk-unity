using System;
using UnityEngine;

namespace AffiseAttributionLib.Native.Android
{
#if UNITY_ANDROID && !UNITY_EDITOR
    internal class NativeAndroid : AndroidJavaProxy, INative
    {
        private const string JavaNativeModules = "com.affise.attribution.unity.AffiseNativeModule";
        private const string JavaNativeEventCallback = "com.affise.attribution.unity.common.NativeEventCallback";
        
        private const string JavaUnityPlayer = "com.unity3d.player.UnityPlayer";
        private const string JavaInvokeMethod = "invokeMethod";
        private const string JavaInvokeMethodVoid = "invokeMethodVoid";

        private readonly AndroidJavaObject _plugin;
        
        private event INative.NativeEventCallback OnNativeEvent;

        public NativeAndroid() : base(JavaNativeEventCallback)
        {
            try
            {
                var unityContext = new AndroidJavaClass(JavaUnityPlayer);
                var activity = unityContext.GetStatic<AndroidJavaObject>("currentActivity");
                var app = activity.Call<AndroidJavaObject>("getApplication");
                _plugin = new AndroidJavaObject(JavaNativeModules, app, this);
            }
            catch (Exception e)
            {
                Debug.LogError($"Error android native module: {e}");
            }
        }

        protected void HandleEvent(string eventName, string data)
        {
            OnNativeEvent?.Invoke(eventName, data);
        }

        public void EventCallback(INative.NativeEventCallback method)
        {
            OnNativeEvent += method;
        }

        public T Native<T>(string name, string json)
        {
            try
            {
                return _plugin.Call<T>(JavaInvokeMethod, name, json);
            }
            catch (AndroidJavaException e)
            {
                Debug.LogError($"AndroidJavaException: {e.Message}");
            }
            catch (Exception e)
            {
                Debug.LogError($"Error native method: {name}: {e}");
            }

            return default;
        }

        public T Native<T>(string name)
        {
            return Native<T>(name, "{}");
        }

        public void Native(string name, string json)
        {
            try
            {
                _plugin.Call(JavaInvokeMethodVoid, name, json);
            }
            catch (Exception e)
            {
                Debug.LogError($"Error native method: {name}: {e}");
            }
        }

        public void Native(string name)
        {
            Native(name, "{}");
        }
    }
#endif
}