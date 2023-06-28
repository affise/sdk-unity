using UnityEngine;
#if UNITY_ANDROID && !UNITY_EDITOR  
using AffiseAttributionLib.Native.Android;
#endif
#if UNITY_IOS && !UNITY_EDITOR  
using AffiseAttributionLib.Native.IOS;
#endif

namespace AffiseAttributionLib.Native
{
    internal abstract class NativeUnity : INative
    {
        private INative _native = null;

        protected NativeUnity()
        {
            Debug.Log("!> NativeUnity");
#if UNITY_ANDROID && !UNITY_EDITOR  
            _native = new NativeAndroid();
#endif
#if UNITY_IOS && !UNITY_EDITOR  
            _native = new NativeIOS();
#endif
            _native?.EventCallback(HandleEvent);
        }

        public T Native<T>(string name, string json)
        {
            return _native.Native<T>(name, json);
        }

        public T Native<T>(string name)
        {
            return _native.Native<T>(name);
        }

        public void Native(string name, string json)
        {
            _native.Native(name, json);
        }

        public void Native(string name)
        {
            _native.Native(name);
        }

        protected abstract void HandleEvent(string eventName, string data);
    }
}