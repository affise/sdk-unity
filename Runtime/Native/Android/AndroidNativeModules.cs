using System;
using UnityEngine;

namespace AffiseAttributionLib.Native.Android
{
    internal abstract class AndroidNativeModules : AndroidJavaProxy
    {
        private const string JavaUnityPlayer = "com.unity3d.player.UnityPlayer";
        private const string JavaNativeEventCallback = "com.affise.attribution.unity.common.NativeEventCallback";
        private const string JavaInvokeMethod = "invokeMethod";
        private const string JavaInvokeMethodVoid = "invokeMethodVoid";

        private readonly AndroidJavaObject _plugin;

        protected AndroidNativeModules(string className) : base(JavaNativeEventCallback)
        {
            try
            {
                var unityContext = new AndroidJavaClass(JavaUnityPlayer);
                var activity = unityContext.GetStatic<AndroidJavaObject>("currentActivity");
                var app = activity.Call<AndroidJavaObject>("getApplication");
                _plugin = new AndroidJavaObject(className, app, this);
            }
            catch (Exception e)
            {
                Debug.LogError($"Error android native module: {e}");
            }
        }

        protected abstract void HandleEvent(string eventName, string data);

        protected T InvokeMethod<T>(string name, string json)
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

        protected T InvokeMethod<T>(string name)
        {
            try
            {
                return _plugin.Call<T>(JavaInvokeMethod, name);
            }
            catch (Exception e)
            {
                Debug.LogError($"Error native method: {name}: {e}");
            }

            return default;
        }

        protected void InvokeMethod(string name, string json)
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

        protected void InvokeMethod(string name)
        {
            try
            {
                _plugin.Call(JavaInvokeMethodVoid, name);
            }
            catch (Exception e)
            {
                Debug.LogError($"Error native method:! {name}: {e}");
            }
        }
    }
}