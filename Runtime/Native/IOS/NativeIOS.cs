#if UNITY_IOS && !UNITY_EDITOR
#nullable enable
using System;
using AffiseAttributionLib.Native.Base;
using UnityEngine;

namespace AffiseAttributionLib.Native.IOS
{
    internal class NativeIOS : INative
    {
        private static event INative.AffiseNativeCallback OnAffiseCallback;
        
        [System.Runtime.InteropServices.DllImport("__Internal", EntryPoint = "_c_affise_api_call")]
        private static extern void apiCall(string apiName, string json);

        [System.Runtime.InteropServices.DllImport("__Internal", EntryPoint = "_c_affise_api_call_bool")]
        private static extern int apiCallBool(string apiName, string json);

        [System.Runtime.InteropServices.DllImport("__Internal", EntryPoint = "_c_affise_api_call_string")]
        private static extern string apiCallString(string apiName, string json);

        [System.Runtime.InteropServices.DllImport("__Internal", EntryPoint = "_c_affise_api_set_callback")]
        private static extern void apiSetCallback(INative.AffiseNativeCallback callback);
        
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
            apiSetCallback(NativeCallback);
        }

        public T Native<T>(string apiName, string json)
        {
            try
            {
                object value = Type.GetTypeCode(typeof(T)) switch
                {
                    TypeCode.Boolean => apiCallBool(apiName, json) != 0,
                    TypeCode.String => apiCallString(apiName, json),
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
                apiCall(apiName, json);
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
#endif // UNITY_IOS && !UNITY_EDITOR