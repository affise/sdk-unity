#nullable enable
using System;
using System.Collections.Generic;
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
        // private bool _enabledMetrics = false;
        private string? _domain;
        // private List<AutoCatchingType> _autoCatchingClickEvents = new();
        private OnInitSuccessHandler? _onInitSuccessHandler;
        private OnInitErrorHandler? _onInitErrorHandler;
        private Dictionary<string, Object> _configValues = new Dictionary<string, object>();

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
         * Set OnInitSuccessHandler
         */
        public AffiseSettings SetOnInitSuccess(OnInitSuccessHandler onInitSuccessHandler)
        {
            _onInitSuccessHandler = onInitSuccessHandler;
            return this;
        }

        /**
         * Set OnInitErrorHandler
         */
        public AffiseSettings SetOnInitError(OnInitErrorHandler onInitErrorHandler)
        {
            _onInitErrorHandler = onInitErrorHandler;
            return this;
        }
        /**
         * Set OnInitErrorHandler
         */
        public AffiseSettings SetConfigValue(AffiseConfig key, Object value)
        {
            if (_configValues.ContainsKey(key.ToValue()))
            {
                _configValues[key.ToValue()] = value;
            }
            else
            {
                _configValues.Add(key.ToValue(), value);
            }
            return this;
        }
        /**
         * Set OnInitErrorHandler
         */
        public AffiseSettings SetConfigValues(Dictionary<AffiseConfig, Object> values)
        {
            foreach (var (key, value) in values)
            {
                SetConfigValue(key, value);
            }

            return this;
        }

        /**
         * Set list of AutoCatchingType
         */
        // public AffiseSettings SetAutoCatchingClickEvents(List<AutoCatchingType> autoCatchingClickEvents)
        // {
        //     _autoCatchingClickEvents = autoCatchingClickEvents;
        //     return this;
        // }
        
        /**
         * Set Metrics [enable]
         */
        // public AffiseSettings SetEnabledMetrics(bool enable)
        // {
        //     _enabledMetrics = enable;
        //     return this;
        // }

        private AffiseInitProperties GetInitProperties()
        {
            return new AffiseInitProperties(
                affiseAppId: _affiseAppId,
                secretKey: _secretKey,
                partParamName: _partParamName,
                partParamNameToken: _partParamNameToken,
                appToken: _appToken,
                isProduction: _isProduction,
                // enabledMetrics: _enabledMetrics,
                // autoCatchingClickEvents: _autoCatchingClickEvents,
                domain: _domain,
                onInitSuccessHandler: _onInitSuccessHandler,
                onInitErrorHandler: _onInitErrorHandler,
                configValues: _configValues
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