#if UNITY_ANDROID && !UNITY_EDITOR
#nullable enable
using System;
using AffiseAttributionLib.Native.Base;
using UnityEngine;

namespace AffiseAttributionLib.Native.Android
{
    internal class NativeAndroid : AndroidJavaProxy, INative
    {
        private const string JavaModule = "com.affise.attribution.unity.AffiseNativeModule";
        private const string JavaAffiseCallback = "com.affise.attribution.internal.callback.OnAffiseCallback";
        
        private const string JavaUnityPlayer = "com.unity3d.player.UnityPlayer";
        private const string JavaApiCall = "apiCall";
        private const string JavaApiCallVoid = "apiCallVoid";
        private const string JavaApiCallBool = "apiCallBool";

        private readonly AndroidJavaObject? _plugin;
        
        private event INative.AffiseNativeCallback? OnAffiseCallback;

        public NativeAndroid() : base(JavaAffiseCallback)
        {
            try
            {
                var unityContext = new AndroidJavaClass(JavaUnityPlayer);
                var activity = unityContext.GetStatic<AndroidJavaObject>("currentActivity");
                var app = activity.Call<AndroidJavaObject>("getApplication");
                _plugin = new AndroidJavaObject(JavaModule, app, this);
            }
            catch (Exception e)
            {
                Debug.LogError($"Module NativeAndroid error: {e}");
            }
        }

        // Java interface signature is case sensitive
        protected void handleCallback(string eventName, string data)
        {
            OnAffiseCallback?.Invoke(eventName, data);
        }

        public void SetCallback(INative.AffiseNativeCallback method)
        {
            OnAffiseCallback += method;
        }

        public void NativeHandleDeeplink(string url)
        {
            if (_plugin is null) return;
            try
            {
                _plugin.Call("nativeHandleDeeplink", url);
            }
            catch (Exception e)
            {
                Debug.LogError($"AffiseApi [ nativeHandleDeeplink ] error: \n {e}");
            }
        }

        public T? Native<T>(string apiName, string json)
        {
            if (_plugin is null) return default;
            try
            {
                object? value = Type.GetTypeCode(typeof(T)) switch
                {
                    TypeCode.Boolean => _plugin.Call<int>(JavaApiCallBool, apiName, json) != 0,
                    _ => _plugin.Call<T>(JavaApiCall, apiName, json)
                };

                if (value is T result)
                {
                    return result;
                }
            }
            catch (AndroidJavaException e)
            {
                Debug.LogError($"NativeAndroid.Native<T>(): {e.Message}");
            }
            catch (Exception e)
            {
                Debug.LogError($"AffiseApi [ {apiName} ] error: {json}:\n {e}");
            }

            return default;
        }

        public T? Native<T>(string apiName)
        {
            return Native<T>(apiName, "{}");
        }

        public void Native(string apiName, string json)
        {
            if (_plugin is null) return;
            try
            {
                _plugin.Call(JavaApiCallVoid, apiName, json);
            }
            catch (Exception e)
            {
                Debug.LogError($"AffiseApi [ {apiName} ] error: {json}:\n {e}");
            }
        }

        public void Native(string apiName)
        {
            Native(apiName, "{}");
        }
    }
}
#endif