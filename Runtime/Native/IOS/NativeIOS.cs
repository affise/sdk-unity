using System;
using UnityEngine;

namespace AffiseAttributionLib.Native.IOS
{
#if UNITY_IOS && !UNITY_EDITOR
    internal class NativeIOS : INative
    {
        private static event INative.NativeEventCallback OnNativeEvent;
        
        [System.Runtime.InteropServices.DllImport("__Internal")]
        private static extern void _c_void_method_json(string methodName, string json);

        [System.Runtime.InteropServices.DllImport("__Internal")]
        private static extern bool _c_bool_method_json(string methodName, string json);

        [System.Runtime.InteropServices.DllImport("__Internal")]
        private static extern string _c_string_method_json(string methodName, string json);

        [System.Runtime.InteropServices.DllImport("__Internal")]
        private static extern void _c_register_callback(INative.NativeEventCallback callback);
        
        [AOT.MonoPInvokeCallback(typeof(INative.NativeEventCallback))]
        protected static void EventCallback(string eventName, string data)
        {
            OnNativeEvent?.Invoke(eventName, data);
        }

        public void EventCallback(INative.NativeEventCallback method)
        {
            OnNativeEvent += method;
        }

        public NativeIOS()
        {
            if (OnNativeEvent is not null)
            {
                foreach (var onNativeDelegate in OnNativeEvent.GetInvocationList())
                {
                    OnNativeEvent -= (INative.NativeEventCallback)onNativeDelegate;
                }
            }
            _c_register_callback(EventCallback);
        }

        public T Native<T>(string name, string json)
        {
            try
            {
                object value = Type.GetTypeCode(typeof(T)) switch
                {
                    TypeCode.Boolean => _c_bool_method_json(name, json),
                    TypeCode.String => _c_string_method_json(name, json),
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
                _c_void_method_json(name, json);
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