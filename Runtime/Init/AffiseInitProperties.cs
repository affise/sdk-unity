#nullable enable
using System.Collections.Generic;
using AffiseAttributionLib.Events;
using AffiseAttributionLib.Network;
using SimpleJSON;

namespace AffiseAttributionLib.Init
{
    public class AffiseInitProperties
    {
        public string AffiseAppId { get; }
        
        public string SecretKey { get; set; }

        public string? PartParamName { get; }

        public string? PartParamNameToken { get; }

        public string? AppToken { get; }

        public bool IsProduction { get; }
        
        public bool EnabledMetrics { get; }

        public List<AutoCatchingType> AutoCatchingClickEvents { get; } = new();
        
        public string? Domain { get; }

        public AffiseInitProperties(
            string affiseAppId, 
            string secretKey,
            bool isProduction = true
        ) : this(
            affiseAppId: affiseAppId,
            secretKey: secretKey,
            isProduction: isProduction,
            partParamName: null,
            partParamNameToken: null,
            appToken: null,
            enabledMetrics: false,
            autoCatchingClickEvents: null,
            domain: null
        )
        {
        }

        public AffiseInitProperties(
            string affiseAppId,
            string secretKey,
            string? partParamName = null,
            string? partParamNameToken = null,
            string? appToken = null,
            bool isProduction = true,
            bool enabledMetrics = false,
            List<AutoCatchingType>? autoCatchingClickEvents = null,
            string? domain = null
        )
        {
            AffiseAppId = affiseAppId;
            SecretKey = secretKey;

            IsProduction = isProduction;
            EnabledMetrics = enabledMetrics;
            
            if (!string.IsNullOrWhiteSpace(partParamName))
            {
                PartParamName = partParamName;
            }

            if (!string.IsNullOrWhiteSpace(partParamNameToken))
            {
                PartParamNameToken = partParamNameToken;
            }

            if (!string.IsNullOrWhiteSpace(appToken))
            {
                AppToken = appToken;
            }

            if (!string.IsNullOrWhiteSpace(domain))
            {
                Domain = domain;
                CloudConfig.SetupDomain(domain);
            }
            
            AutoCatchingClickEvents = autoCatchingClickEvents ?? new List<AutoCatchingType>();
        }

        private AffiseInitProperties(AffiseInitProperties props)
        {
            AffiseAppId = props.AffiseAppId;
            SecretKey = props.SecretKey;
            IsProduction = props.IsProduction;
            PartParamName = props.PartParamName;
            PartParamNameToken = props.PartParamNameToken;
            AppToken = props.AppToken;
            EnabledMetrics = props.EnabledMetrics;
            AutoCatchingClickEvents = props.AutoCatchingClickEvents;
            Domain = props.Domain;
        }

        public AffiseInitProperties Copy() => new(this);

        public JSONObject ToJson =>
            new()
            {
                ["affiseAppId"] = AffiseAppId,
                ["isProduction"] = IsProduction,
                ["partParamName"] = PartParamName,
                ["partParamNameToken"] = PartParamNameToken,
                ["appToken"] = AppToken,
                ["secretKey"] = SecretKey,
                ["enabledMetrics"] = EnabledMetrics,
                ["autoCatchingClickEvents"] = AutoCatchingClickEvents.ToJsonArray(),
                ["domain"] = Domain,
            };
    }
}