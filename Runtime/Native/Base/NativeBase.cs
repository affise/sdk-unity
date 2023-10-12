#nullable enable
using System;
using System.Collections.Generic;
using AffiseAttributionLib.Extensions;
using AffiseAttributionLib.Native.Base;
using AffiseAttributionLib.Utils;
using SimpleJSON;
#if UNITY_ANDROID && !UNITY_EDITOR
using AffiseAttributionLib.Native.Android;
#endif

#if UNITY_IOS && !UNITY_EDITOR
using AffiseAttributionLib.Native.IOS;
#endif

namespace AffiseAttributionLib.Native
{
    internal abstract class NativeBase
    {
        private const string UUID = "callback_uuid";

        private INative? _native = null;

        private readonly Dictionary<string, object> _callbacksOnce = new();
        
        private readonly Dictionary<AffiseApiMethod, object> _callbacks = new();

        protected NativeBase()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            _native = new NativeAndroid();
#endif
#if UNITY_IOS && !UNITY_EDITOR
            _native = new NativeIOS();
#endif
            _native?.SetCallback(AffiseCallback);
        }

        protected abstract void HandleCallback(AffiseApiMethod api, object callback, JSONNode? json);

        protected T? Native<T>(AffiseApiMethod api, object? data, string? uuid = null)
        {
            var json = new JSONObject
            {
                [api.ToMethod()] = data?.ToJsonNode(),
                [UUID] = uuid
            };
            if (_native is null) return default;
            return _native.Native<T>(api.ToMethod(), json.ToString());
        }

        protected T? Native<T>(AffiseApiMethod api)
        {
            if (_native is null) return default;
            return _native.Native<T>(api.ToMethod());
        }

        protected void Native(AffiseApiMethod api, object? data)
        {
            var json = new JSONObject
            {
                [api.ToMethod()] = data?.ToJsonNode(),
            };
            _native?.Native(api.ToMethod(), json.ToString());
        }

        protected void Native(AffiseApiMethod api)
        {
            _native?.Native(api.ToMethod());
        }

        protected JSONObject? NativeMap(AffiseApiMethod api)
        {
            try
            {
                var data = Native<string>(api);
                return JSON.Parse(data).AsObject;
            }
            catch (Exception)
            {
                // ignored
            }

            return null;
        }

        protected JSONArray? NativeList(AffiseApiMethod api)
        {
            try
            {
                var data = Native<string>(api);
                return JSON.Parse(data).AsArray;
            }
            catch (Exception)
            {
                // ignored
            }
            return null;
        }

        protected void NativeCallbackOnce(AffiseApiMethod api, object callback, object? data = null)
        {
            var uuid = Uuid.Generate();
            var json = new JSONObject
            {
                [api.ToMethod()] = data?.ToJsonNode(),
                [UUID] = uuid
            };
            _callbacksOnce[uuid] = callback;
            _native?.Native(api.ToMethod(), json.ToString());
        }
        
        protected void NativeCallback(AffiseApiMethod api, object callback, object? data = null)
        {
            var json = new JSONObject
            {
                [api.ToMethod()] = data?.ToJsonNode(),
            };
            _callbacks[api] = callback;
            _native?.Native(api.ToMethod(), json.ToString());
        }

        private void AffiseCallback(string apiName, string data)
        {
            var api = apiName.ToAffiseApiMethod();
            if (api is null) return;
            var (uuid, json) = GetCallbackValue(data, api);
            if (uuid is null)
            {
                GetCallback(api, callback =>
                {
                    OnCallbackCall(api, callback, json);
                });
            }
            else
            {
                GetCallbackOnce(uuid, callback =>
                {
                    OnCallbackCall(api, callback, json);
                });
            }
        }

        private void OnCallbackCall(AffiseApiMethod? api, object? callback, JSONNode? json)
        {
            if (api is null)  return;
            if (callback is null)  return;
            HandleCallback((AffiseApiMethod)api, callback, json);
        }

        private Tuple<string?, JSONNode?> GetCallbackValue(string data, AffiseApiMethod? api)
        {
            try
            {
                var json = JSON.Parse(data);
                var uuid = json[UUID];
                if (api is null)
                {
                    return new Tuple<string?, JSONNode?>(uuid, null);
                }

                var value = json[api?.ToMethod()];
                return new Tuple<string?, JSONNode?>(uuid, value);
            }
            catch (Exception)
            {
                // ignored
            }
            return new Tuple<string?, JSONNode?>(null, null);
        }

        private void GetCallbackOnce(string? uuid, Action<object?> action)
        {
            if (uuid is null) return;
            if (!_callbacksOnce.ContainsKey(uuid)) return;
            action.Invoke(_callbacksOnce[uuid]);
            _callbacksOnce.Remove(uuid);
        }
        
        private void GetCallback(AffiseApiMethod? api, Action<object?> action)
        {
            if (api is null) return;
            var key = (AffiseApiMethod)api;
            if (!_callbacks.ContainsKey(key))
            {
                return;
            }
            action.Invoke(_callbacks[key]);
        }
    }
}