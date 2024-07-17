#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using AffiseAttributionLib;
using AffiseAttributionLib.Events.Subscription;
using AffiseAttributionLib.Referrer;
using UnityEngine;
using UnityEngine.UIElements;

namespace AffiseDemo
{
    public class AffiseDemo : BaseUi
    {
        private readonly DefaultEventsFactory _eventsFactory = new ();
        private readonly AffiseApiFactory _apiFactory = new();

        protected override void Init()
        {
            _apiFactory.Output = Output;
        
            AffiseInit();
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
                // Debug.Log($"Affise: {request}");
                Debug.Log($"Affise: {response}");
            });

            // Deeplinks https://github.com/affise/sdk-unity#deeplinks
            Affise.RegisterDeeplinkCallback(value =>
            {
                var list = value.Parameters.Select(h => $"{h.Key}=[{string.Join(", ", h.Value)}]").ToList();
                var parameters = string.Join(", ", list);
                Output($"Deeplink: {value.Deeplink}\n\n" +
                       $"scheme={value.Scheme}\n" +
                       $"host={value.Host}\n" +
                       $"path={value.Path}\n" +
                       $"parameters=[{parameters}]"
                );
            });
        }

        protected override void ApiView(VisualElement view)
        {
            view.Clear();
            
            foreach (var (apiName, apiCall) in _apiFactory.Create())
            {
                if (apiName == "Get Referrer Value")
                {
                    AddDropdown(view, "", ReferrerValues(), value =>
                    {
                        _apiFactory.ReferrerValue = value;
                    });
                }

                AddButton(view, apiName,null, apiCall);
            }
        }

        protected override void EventsView(VisualElement view)
        {
            view.Clear();
            
            foreach (var affiseEvent in _eventsFactory.CreateEvents())
            {
                var styleClass = (affiseEvent is BaseSubscriptionEvent) 
                    ? "affise-subscription-event"
                    : null;

                AddButton(view, ToCamelCase(affiseEvent.GetName()), styleClass, () => { 
                    // Events tracking https://github.com/affise/sdk-unity#events-tracking
                    // Send event
                    affiseEvent.Send();
                    // or
                    // Affise.SendEvent(affiseEvent);
                    // or
                    // affiseEvent.SendNow(() =>
                    // {
                    //     Output($"Send {affiseEvent.GetName()} success");
                    // }, (status) =>
                    // {
                    //     Output($"Send {affiseEvent.GetName()} failed {status}");
                    // });
                });
            }
        }

        private static List<string> ReferrerValues()
        {
            return Enum.GetValues(typeof(ReferrerKey))
                .Cast<ReferrerKey>()
                .Select(s => s.ToString())
                .ToList();
        }
    }
}
