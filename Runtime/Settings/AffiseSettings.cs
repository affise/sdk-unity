#nullable enable
using System.Collections.Generic;
using AffiseAttributionLib.Events;
using AffiseAttributionLib.Init;

namespace AffiseAttributionLib.Settings
{
    public sealed class AffiseSettings
    {
        private readonly string _affiseAppId;
        private readonly string _secretKey;
        private string? _partParamName;
        private string? _partParamNameToken;
        private string? _appToken;
        private bool _isProduction = true;
        private bool _enabledMetrics = false;
        private string? _domain;
        private List<AutoCatchingType> _autoCatchingClickEvents = new();

        /**
         * Affise SDK settings
         *
         * [affiseAppId] - your app id
         * [secretKey] - your SDK secretKey
         */
        internal AffiseSettings(string affiseAppId, string secretKey)
        {
            _affiseAppId = affiseAppId;
            _secretKey = secretKey;
        }

        /**
         * Set Affise SDK for SandBox / Production
         */
        public AffiseSettings SetProduction(bool production)
        {
            _isProduction = production;
            return this;
        }

        /**
         * Set Affise SDK server domain.
         * Trailing slash is irrelevant
         */
        public AffiseSettings SetDomain(string domain)
        {
            _domain = domain;
            return this;
        }

        /**
         * Only for specific use case
         */
        public AffiseSettings SetPartParamName(string partParamName)
        {
            _partParamName = partParamName;
            return this;
        }

        /**
         * Only for specific use case
         */
        public AffiseSettings SetPartParamNameToken(string partParamNameToken)
        {
            _partParamNameToken = partParamNameToken;
            return this;
        }

        /**
         * Set appToken
         */
        public AffiseSettings SetAppToken(string appToken)
        {
            _appToken = appToken;
            return this;
        }

        /**
         * Set list of AutoCatchingType
         */
        public AffiseSettings SetAutoCatchingClickEvents(List<AutoCatchingType> autoCatchingClickEvents)
        {
            _autoCatchingClickEvents = autoCatchingClickEvents;
            return this;
        }
        
        /**
         * Set Metrics [enable]
         */
        public AffiseSettings SetEnabledMetrics(bool enable)
        {
            _enabledMetrics = enable;
            return this;
        }

        private AffiseInitProperties GetInitProperties()
        {
            return new AffiseInitProperties(
                affiseAppId: _affiseAppId,
                secretKey: _secretKey,
                partParamName: _partParamName,
                partParamNameToken: _partParamNameToken,
                appToken: _appToken,
                isProduction: _isProduction,
                enabledMetrics: _enabledMetrics,
                autoCatchingClickEvents: _autoCatchingClickEvents,
                domain: _domain
            );
        }

        /**
         * Starts Affise SDK
         */
        public void Start()
        {
            Affise.Start(GetInitProperties());
        }
    }
}