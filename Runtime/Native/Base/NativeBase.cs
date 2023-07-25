#nullable enable
using System;
using System.Collections.Generic;
using AffiseAttributionLib.Extensions;
using AffiseAttributionLib.Native.Base;
using AffiseAttributionLib.Utils;
using SimpleJSON;
using UnityEngine;
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

        private readonly Dictionary<string, object> _callbacks = new();

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

        protected abstract void HandleCallback(AffiseApiMethod? api, object callback, JSONNode? json);

        protected T? Native<T>(AffiseApiMethod api, object? data, string? uuid = null)
        {
            var json = new JSONObject
            {
                [api.ToValue()] = data?.ToJsonNode(),
                [UUID] = uuid
            };
            if (_native is null) return default;
            return _native.Native<T>(api.ToValue(), json.ToString());
        }

        protected T? Native<T>(AffiseApiMethod api)
        {
            if (_native is null) return default;
            return _native.Native<T>(api.ToValue());
        }

        protected void Native(AffiseApiMethod api, object? data)
        {
            var json = new JSONObject
            {
                [api.ToValue()] = data?.ToJsonNode(),
            };
            _native?.Native(api.ToValue(), json.ToString());
        }

        protected void Native(AffiseApiMethod api)
        {
            _native?.Native(api.ToValue());
        }

        protected void NativeCallback(AffiseApiMethod api, object callback, object? data = null)
        {
            var uuid = Uuid.Generate();
            var json = new JSONObject
            {
                [api.ToValue()] = data?.ToJsonNode(),
                [UUID] = uuid
            };
            _callbacks[uuid] = callback;
            _native?.Native(api.ToValue(), json.ToString());
        }

        private void AffiseCallback(string apiName, string data)
        {
            var api = apiName.ToAffiseApiMethod();
            if (api is null) return;
            var (uuid, json) = GetCallbackValue(data, api);
            if (uuid is null) return;
            GetCallback(uuid, callback =>
            {
                if (callback is null) 
                {
                    Debug.LogWarning($"AffiseCallback(string, data) callback is null for UUID: {uuid}");
                    return;
                } 
                HandleCallback(api, callback, json);
            });
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

                var value = json[api?.ToValue()];
                return new Tuple<string?, JSONNode?>(uuid, value);
            }
            catch (Exception e)
            {
                Debug.LogError(e);
                return new Tuple<string?, JSONNode?>(null, null);
            }
        }

        private void GetCallback(string? uuid, Action<object?> action)
        {
            if (uuid is null) return;
            if (!_callbacks.ContainsKey(uuid))
            {
                Debug.LogWarning($"GetCallback(string, Action) callback for UUID not found: {uuid}");
                return;
            }

            action.Invoke(_callbacks[uuid]);
            _callbacks.Remove(uuid);
        }
    }
}