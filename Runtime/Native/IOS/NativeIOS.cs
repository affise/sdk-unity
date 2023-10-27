#if UNITY_IOS && !UNITY_EDITOR
using System;
using AffiseAttributionLib.Native.Base;
using UnityEngine;

namespace AffiseAttributionLib.Native.IOS
{
    internal class NativeIOS : INative
    {
        private static event INative.AffiseNativeCallback OnAffiseCallback;
        
        [System.Runtime.InteropServices.DllImport("__Internal")]
        private static extern void _c_api_call(string apiName, string json);

        [System.Runtime.InteropServices.DllImport("__Internal")]
        private static extern int _c_api_call_bool(string apiName, string json);

        [System.Runtime.InteropServices.DllImport("__Internal")]
        private static extern string _c_api_call_string(string apiName, string json);

        [System.Runtime.InteropServices.DllImport("__Internal")]
        private static extern void _c_register_callback(INative.AffiseNativeCallback callback);
        
        [AOT.MonoPInvokeCallback(typeof(INative.AffiseNativeCallback))]
        protected static void NativeCallback(string eventName, string data)
        {
            OnAffiseCallback?.Invoke(eventName, data);
        }

        public void SetCallback(INative.AffiseNativeCallback method)
        {
            OnAffiseCallback += method;
        }

        public NativeIOS()
        {
            if (OnAffiseCallback is not null)
            {
                foreach (var onNativeDelegate in OnAffiseCallback.GetInvocationList())
                {
                    OnAffiseCallback -= (INative.AffiseNativeCallback)onNativeDelegate;
                }
            }
            _c_register_callback(NativeCallback);
        }

        public T Native<T>(string apiName, string json)
        {
            try
            {
                object value = Type.GetTypeCode(typeof(T)) switch
                {
                    TypeCode.Boolean => _c_api_call_bool(apiName, json) != 0,
                    TypeCode.String => _c_api_call_string(apiName, json),
                    _ => null
                };
                
                if (value is T)
                {
                    return (T)value;
                }
                return default;
            }
            catch (Exception e)
            {
                Debug.LogError($"AffiseApi [ {apiName} ] error: {json}:\n {e}");
            }
            return default;
        }

        public T Native<T>(string apiName)
        {
            return Native<T>(apiName, "{}");
        }

        public void Native(string apiName, string json)
        {
            try
            {
                _c_api_call(apiName, json);
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