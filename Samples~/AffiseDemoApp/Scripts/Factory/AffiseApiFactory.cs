#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using AffiseAttributionLib;
using AffiseAttributionLib.AffiseParameters;
using AffiseAttributionLib.Modules;
using AffiseAttributionLib.Referrer;
using AffiseAttributionLib.Utils;
using UnityEngine;
#if UNITY_IOS
using AffiseAttributionLib.SKAd;
#endif // UNITY_IOS

namespace AffiseDemo
{
    public class AffiseApiFactory
    {
        public string ReferrerValue = ReferrerKey.AD_ID.ToString();

        public Action<string>? Output = null;
        public Action<string, string>? Alert = null;

        private void Print(string value)
        {
            Output?.Invoke(value);
        }
        
        private void AlertMsg(string title, string message)
        {
            Alert?.Invoke(title, message);
        }

        public Dictionary<string, Action> Create()
        {
            return new Dictionary<string, Action>
            {
                { "Debug: Reset", () => { PlayerPrefs.DeleteAll(); } },
                { "Debug: IsFirstRun", () => { Print($"IsFirstRun: {Affise.IsFirstRun()}"); } },
                {
                    "Debug: Validate credentials", () =>
                    {
                        // Debug: Validate credentials https://github.com/affise/sdk-unity#validate-credentials
                        Affise.Debug.Validate(status => { Print($"Validate: {status}"); });
                    }
                },
                {
                    "RegisterDeeplinkCallback", () =>
                    {
                        // Deeplinks https://github.com/affise/sdk-unity#deeplinks
                        Affise.RegisterDeeplinkCallback(value =>
                        {
                            var list = value.Parameters.Select(h => $"{h.Key}=[{string.Join(", ", h.Value)}]").ToList();
                            var parameters = string.Join(", ", list);
                            AlertMsg("Deeplink", $"{value.Deeplink}\n\n" +
                                     $"scheme={value.Scheme}\n" +
                                     $"host={value.Host}\n" +
                                     $"path={value.Path}\n" +
                                     $"parameters=[{parameters}]"
                            );
                        });
                    }
                },
                {
                    "Get Referrer Url", () =>
                    {
                        // Get referrer https://github.com/affise/sdk-unity#get-referrer
                        Affise.GetReferrerUrl(value => { Print($"GetReferrer: {value}"); });
                    }
                },
                {
                    "Get Referrer Url Value", () =>
                    {
                        // Get referrer parameter https://github.com/affise/sdk-unity#get-referrer-parameter
                        Affise.GetReferrerUrlValue(ToReferrer(ReferrerValue),
                            value => { Print($"GetReferrerValue: {ReferrerValue} = {value}"); });
                    }
                },
                {
                    "Get Status", () =>
                    {
                        // Get module status https://github.com/affise/sdk-unity#get-module-state
                        Affise.Module.GetStatus(AffiseModules.Status, value =>
                        {
                            Print($"GetStatus: Count = {value.Count}");
                            Print($"- {string.Join("\n- ", value)}");
                        });
                    }
                },
                {
                    "Get Modules Installed", () =>
                    {
                        // Get modules installed https://github.com/affise/sdk-unity#modules
                        var value = Affise.Module.GetModulesInstalled();
                        Print($"Modules: [{string.Join(',', value)}]");
                    }
                },
#if UNITY_IOS
                {
                    "iOS: Get Referrer On Server", () =>
                    {
                        // Get referrer https://github.com/affise/sdk-unity#get-referrer-on-server
                        Affise.IOS.GetReferrerOnServer(value => { Print($"GetReferrerOnServer: {value}"); });
                    }
                },
                {
                    "iOS: Get Referrer On Server Value", () =>
                    {
                        // Get referrer parameter https://github.com/affise/sdk-unity#get-referrer-on-server-parameter
                        Affise.IOS.GetReferrerOnServerValue(ToReferrer(ReferrerValue),
                            value => { Print($"GetReferrerOnServerValue: {ReferrerValue} = {value}"); });
                    }
                },
                {
                    "iOS: SKAd Register", () =>
                    {
                        // StoreKit Ad Network https://github.com/affise/sdk-unity#storekit-ad-network
                        Affise.IOS.RegisterAppForAdNetworkAttribution(error => { Print($"SKAd Register: {error}"); });
                    }
                },
                {
                    "iOS: SKAd Postback", () =>
                    {
                        // StoreKit Ad Network https://github.com/affise/sdk-unity#storekit-ad-network
                        Affise.IOS.UpdatePostbackConversionValue(
                            1,
                            SKAdNetwork.CoarseConversionValue.Medium,
                            error => { Print($"SKAd Postback: {error}"); });
                    }
                },
#endif // UNITY_IOS
                {
                    "Random push Token", () =>
                    {
                        var token = Uuid.Generate();
                        // Push token tracking https://github.com/affise/sdk-unity#push-token-tracking
                        Affise.AddPushToken(token);
                        Print($"AddPushToken: {token}");
                    }
                },
                {
                    "Is Offline Mode", () =>
                    {
                        // Offline mode https://github.com/affise/sdk-unity#offline-mode
                        var value = Affise.IsOfflineModeEnabled() ?? false;
                        Print($"IsOfflineModeEnabled: {(value ? "true" : "false")}");
                    }
                },
                {
                    "Set Offline Mode", () =>
                    {
                        // Offline mode https://github.com/affise/sdk-unity#offline-mode
                        var value = Affise.IsOfflineModeEnabled() ?? false;
                        Affise.SetOfflineModeEnabled(!value);
                        Print($"SetOfflineModeEnabled: {(!value ? "true" : "false")}");
                    }
                },
                {
                    "Get Random User Id", () =>
                    {
                        // Get random user Id https://github.com/affise/sdk-unity#get-random-user-id
                        var value = Affise.GetRandomUserId();
                        Print($"GetRandomUserId: {value}");
                    }
                },
                {
                    "Get Random Device Id", () =>
                    {
                        // Get random device Id https://github.com/affise/sdk-unity#get-random-device-id
                        var value = Affise.GetRandomDeviceId();
                        Print($"GetRandomDeviceId: {value}");
                    }
                },
                {
                    "Get Providers", () =>
                    {
                        // Get providers https://github.com/affise/sdk-unity#get-providers
                        var providers = Affise.GetProviders();
                        var key = ProviderType.AFFISE_APP_TOKEN;
                        if (providers.ContainsKey(key))
                        {
                            Print($"GetProviders: {key.Provider()} = {providers[key]}");
                        }
                        else
                        {
                            Print($"GetProviders: key = {key.Provider()} not found");
                        }

                        // foreach (var (type, value) in providers)
                        // {
                        //     Console.WriteLine($"{type.Provider()} = {value}");
                        // }
                    }
                },
                // { "", () => { } },
            };
        }
        
        private static ReferrerKey ToReferrer(string referrerName)
        {
            Enum.TryParse(referrerName, out ReferrerKey referrer);
            return referrer;
        }
    }
}
