#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using AffiseAttributionLib;
using AffiseAttributionLib.Modules;
using AffiseAttributionLib.Referrer;
using AffiseAttributionLib.SKAd;
using AffiseAttributionLib.Utils;
using UnityEngine;
using UnityEngine.UIElements;

namespace AffiseDemo
{
    [RequireComponent(typeof(DefaultEventsFactory))]
    [RequireComponent(typeof(UIDocument))]
    public class AffiseDemo : MonoBehaviour
    {
        #region setup

        #region variables

        private DefaultEventsFactory? _eventsFactory;
        private ScrollView? _eventScrollView;
        private ScrollView? _apiScrollView;
        private VisualElement? _root;
        private VisualElement? _safeZone;
        private TextField? _output;
        private bool _isApi = true;

        private ReferrerKey _refKey;

        private Dictionary<CallbackEventHandler, EventCallback<ClickEvent>> _ClickCallback = new();

        #endregion variables

        private void Start()
        {
            BindView();

            InitApi(_apiScrollView);
            InitEvents(_eventScrollView);
        }

        private void OnDestroy()
        {
            UnBindView();
        }

        private void BindView()
        {
            _eventsFactory = GetComponent<DefaultEventsFactory>();

            _root = GetComponent<UIDocument>().rootVisualElement;

            _safeZone = _root.Q<VisualElement>("safe-zone");
            _safeZone.RegisterCallback<GeometryChangedEvent>(LayoutChanged);

            _eventScrollView = _root.Q<ScrollView>("events");
            _apiScrollView = _root.Q<ScrollView>("api");

            _output = _root.Q<TextField>("output");

            BindButton("toggle-btn", ToggleMode);

            BindButton("output-clear", () =>
            {
                _output.value = "";
            });
        }

        private void UnBindView()
        {
            _safeZone?.UnregisterCallback<GeometryChangedEvent>(LayoutChanged);
            UnBindButtons();
        }

        private void Output(string msg)
        {
            if (_output is null) return;
            if (string.IsNullOrWhiteSpace(_output.value))
            {
                _output.value = msg;
            }
            else
            {
                _output.value = $"{_output.value}\n{msg}";
            }
        }

        private void ToggleMode()
        {
            _isApi = !_isApi;
            _apiScrollView.Show(_isApi);
            _eventScrollView.Hide(_isApi);
        }

        private void UnBindButtons()
        {
            foreach (var (button, callback) in _ClickCallback)
            {
                button.UnregisterCallback(callback);
            }

            _ClickCallback.Clear();
        }

        private Button BindButton(string btnName, Action action)
        {
            EventCallback<ClickEvent> callback = (_) => 
            {
                action.Invoke();
            };

            var button = _root.Q<Button>(btnName);
            button.RegisterCallback(callback);

            _ClickCallback[button] = callback;

            return button;
        }

        private void LayoutChanged(GeometryChangedEvent e)
        {
            (e.target as VisualElement)?.SafeAreaMargin();
        }

        #endregion setup

        private void InitApi(VisualElement? view)
        {
            if (view is null) return;

            view.AddButton("RegisterDeeplinkCallback", () =>
            {
                Affise.RegisterDeeplinkCallback(uri =>
                {
                    Output($"Deeplink: {uri}");
                    return true;
                });
            });
            
            view.AddButton("Get Referrer", () =>
            {
                Affise.Android.GetReferrer(value =>
                {
                    Output($"GetReferrer: {value}");
                });
            });

            view.AddDropdown("", ReferrerValues(), refName =>
            {
                _refKey = ToReferrer(refName);
            });

            view.AddButton("Get Referrer Value", () => 
            {
                Affise.Android.GetReferrerValue(_refKey, value =>
                {
                    Output($"GetReferrerValue: {_refKey.ToString()} = {value}");
                });
            });

            view.AddButton("Get Status", () =>
            {
                Affise.GetStatus(AffiseModules.Status, value =>
                {
                    Output($"GetStatus: Count = {value.Count}");
                    foreach (var keyValue in value)
                    {
                        Output($"GetStatus: {keyValue.Key}: {keyValue.Value}");
                    }
                });
            });

#if UNITY_IOS
            view.AddButton("SKAd Register", () =>
            {
                Affise.IOS.RegisterAppForAdNetworkAttribution(error =>
                {
                    Output($"SKAd Register: {error}");
                });
            });
            
            view.AddButton("SKAd Postback", () =>
            {
                Affise.IOS.UpdatePostbackConversionValue(
                    1,
                    SKAdNetwork.CoarseConversionValue.Medium,
                    error =>
                    {
                        Output($"SKAd Postback: {error}");
                    });
            });
#endif

            view.AddButton("Random push Token", () =>
            {
                var token = Uuid.Generate();
                Affise.AddPushToken(token);
                Output($"AddPushToken: {token}");
            });

            view.AddButton("Is Offline Mode", () =>
            {
                var value = Affise.IsOfflineModeEnabled() ?? false;
                Output($"IsOfflineModeEnabled: {(value ? "true" : "false")}");
            });

            view.AddButton("Get Random User Id", () =>
            {
                var value = Affise.GetRandomUserId();
                Output($"GetRandomUserId: {value}");
            });

            view.AddButton("Get Random Device Id", () =>
            {
                var value = Affise.GetRandomDeviceId();
                Output($"GetRandomDeviceId: {value}");
            });
        }

        private void InitEvents(VisualElement? view)
        {
            if (view is null) return;
            view.Clear();
            if (_eventsFactory is null) return;
            foreach (var affiseEvent in _eventsFactory.CreateEvents())
            {
                view.AddButton(affiseEvent.GetName(), () => { 
                    // Send event
                    affiseEvent.Send();
                    // or
                    // Affise.SendEvent(affiseEvent);
                });
            }
        }

        private List<string> ReferrerValues()
        {
            return Enum.GetValues(typeof(ReferrerKey))
                .Cast<ReferrerKey>()
                .Select(s => s.ToString())
                .ToList();
        }

        private ReferrerKey ToReferrer(string referrerName)
        {
            Enum.TryParse(referrerName, out ReferrerKey referrer);
            return referrer;
        }
    }
}
