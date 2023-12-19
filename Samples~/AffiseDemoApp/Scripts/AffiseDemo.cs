#nullable enable
using System;
using System.Collections.Generic;
using AffiseAttributionLib;
using AffiseAttributionLib.AffiseParameters;
using AffiseAttributionLib.Executors;
using AffiseAttributionLib.Init;
using AffiseAttributionLib.Modules;
using AffiseAttributionLib.Referrer;
using AffiseAttributionLib.Utils;
using UnityEngine;
using UnityEngine.UIElements;
#if UNITY_IOS
using AffiseAttributionLib.SKAd;
#endif

namespace AffiseDemo
{
    [RequireComponent(typeof(DefaultEventsFactory))]
    [RequireComponent(typeof(UIDocument))]
    public class AffiseDemo : MonoBehaviour
    {
        #region variables

        private DefaultEventsFactory? _eventsFactory;
        private ScrollView? _eventScrollView;
        private ScrollView? _apiScrollView;
        private VisualElement? _root;
        private VisualElement? _safeZone;
        private TextField? _output;
        private bool _isApi = true;

        private ReferrerKey _refKey;

        private readonly Dictionary<CallbackEventHandler, EventCallback<ClickEvent>> _clickCallback = new();

        private ContextThreadExecutor? _contextExecutor;

        #endregion variables

        private void Start()
        {
            _contextExecutor = new ContextThreadExecutor();
            
            BindView();
        
            AffiseInit();
            AffiseApi(_apiScrollView);
            AffiseEvents(_eventScrollView);
        }

        private void OnDestroy()
        {
            UnBindView();
        }

        private void AffiseInit()
        {
            // Initialize https://github.com/affise/sdk-unity#manual
            // For manual init delete "Affise Settings.asset" or disable [isActive] flag  
            // Affise
            //     .Settings(
            //         affiseAppId: "129",
            //         secretKey: "93a40b54-6f12-443f-a250-ebf67c5ee4d2"
            //     )
            //     .SetProduction(false) //To enable debug methods set Production to false
            //     .Start(); // Start Affise SDK

            // Debug: network request/response
            Affise.Debug.Network((request, response) =>
            {
                Debug.Log($"Affise: {request}");
                Debug.Log($"Affise: {response}");
            });
        }

        private void AffiseApi(VisualElement? view)
        {
            if (view is null) return;

            view.AddButton("Debug: Validate credentials", () =>
            {
                // Debug: Validate credentials https://github.com/affise/sdk-unity#validate-credentials
                Affise.Debug.Validate(status =>
                {
                    Output($"Validate: {status}");
                });
            });
            
            view.AddButton("RegisterDeeplinkCallback", () =>
            {
                // Deeplinks https://github.com/affise/sdk-unity#deeplinks
                Affise.RegisterDeeplinkCallback(uri =>
                {
                    Output($"Deeplink: {uri}");
                    return true;
                });
            });
            
            view.AddButton("Get Referrer", () =>
            {
                // Get referrer https://github.com/affise/sdk-unity#get-referrer
                Affise.GetReferrer(value =>
                {
                    Output($"GetReferrer: {value}");
                });
            });

            AddReferrerDropdown(view);

            view.AddButton("Get Referrer Value", () => 
            {
                // Get referrer parameter https://github.com/affise/sdk-unity#get-referrer-parameter
                Affise.GetReferrerValue(_refKey, value =>
                {
                    Output($"GetReferrerValue: {_refKey.ToString()} = {value}");
                });
            });

            view.AddButton("Get Status", () =>
            {
                // Get module status https://github.com/affise/sdk-unity#get-module-state
                Affise.GetStatus(AffiseModules.Status, value =>
                {
                    Output($"GetStatus: Count = {value.Count}");
                    Output($"- {string.Join("\n- ", value)}");
                });
            });

#if UNITY_IOS
            view.AddButton("SKAd Register", () =>
            {
                // StoreKit Ad Network https://github.com/affise/sdk-unity#storekit-ad-network
                Affise.IOS.RegisterAppForAdNetworkAttribution(error =>
                {
                    Output($"SKAd Register: {error}");
                });
            });
            
            view.AddButton("SKAd Postback", () =>
            {
                // StoreKit Ad Network https://github.com/affise/sdk-unity#storekit-ad-network
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
                // Push token tracking https://github.com/affise/sdk-unity#push-token-tracking
                Affise.AddPushToken(token);
                Output($"AddPushToken: {token}");
            });

            view.AddButton("Is Offline Mode", () =>
            {
                // Offline mode https://github.com/affise/sdk-unity#offline-mode
                var value = Affise.IsOfflineModeEnabled() ?? false;
                Output($"IsOfflineModeEnabled: {(value ? "true" : "false")}");
            });

            view.AddButton("Set Offline Mode", () =>
            {
                // Offline mode https://github.com/affise/sdk-unity#offline-mode
                var value = Affise.IsOfflineModeEnabled() ?? false;
                Affise.SetOfflineModeEnabled(!value);
                Output($"SetOfflineModeEnabled: {(!value ? "true" : "false")}");
            });

            view.AddButton("Get Random User Id", () =>
            {
                // Get random user Id https://github.com/affise/sdk-unity#get-random-user-id
                var value = Affise.GetRandomUserId();
                Output($"GetRandomUserId: {value}");
            });

            view.AddButton("Get Random Device Id", () =>
            {
                // Get random device Id https://github.com/affise/sdk-unity#get-random-device-id
                var value = Affise.GetRandomDeviceId();
                Output($"GetRandomDeviceId: {value}");
            });

            view.AddButton("Get Providers", () =>
            {
                // Get providers https://github.com/affise/sdk-unity#get-providers
                var providers = Affise.GetProviders();
                var key = ProviderType.AFFISE_APP_TOKEN;
                if (providers.ContainsKey(key))
                {
                    Output($"GetProviders: {key.Provider()} = {providers[key]}");
                }
                else
                {
                    Output($"GetProviders: key = {key.Provider()} not found");
                }

                // foreach (var (type, value) in providers)
                // {
                //     Console.WriteLine($"{type.Provider()} = {value}");
                // }
            });
        }

        private void AffiseEvents(VisualElement? view)
        {
            if (view is null) return;
            view.Clear();
            if (_eventsFactory is null) return;
            foreach (var affiseEvent in _eventsFactory.CreateEvents())
            {
                view.AddButton(affiseEvent.GetName(), () => { 
                    // Events tracking https://github.com/affise/sdk-unity#events-tracking
                    // Send event
                    affiseEvent.Send();
                    // or
                    // Affise.SendEvent(affiseEvent);
                });
            }
        }

        #region UI utils
        
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
            _contextExecutor?.Run(() => OutputTextUI(msg));
        }

        private void OutputTextUI(string msg)
        {
            if (_output is null) return;
            if (string.IsNullOrWhiteSpace(_output.value))
            {
                _output.value = $"{msg}";
            }
            else
            {
                _output.value += $"\n{msg}";
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
            foreach (var (button, callback) in _clickCallback)
            {
                button.UnregisterCallback(callback);
            }

            _clickCallback.Clear();
        }

        private Button BindButton(string btnName, Action action)
        {
            EventCallback<ClickEvent> callback = (_) => 
            {
                action.Invoke();
            };

            var button = _root.Q<Button>(btnName);
            button.RegisterCallback(callback);

            _clickCallback[button] = callback;

            return button;
        }

        private void LayoutChanged(GeometryChangedEvent e)
        {
            (e.target as VisualElement)?.SafeAreaMargin();
        }

        private void AddReferrerDropdown(VisualElement view)
        {
            view.AddDropdown("", AffiseDemoUtils.ReferrerValues(), refName =>
            {
                _refKey = AffiseDemoUtils.ToReferrer(refName);
            });
        }

        #endregion UI utils
    }
}
