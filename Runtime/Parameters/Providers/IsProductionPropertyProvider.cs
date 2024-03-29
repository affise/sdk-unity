﻿using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Init;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.AFFISE_SDK_POS]
     */
    internal class IsProductionPropertyProvider : StringPropertyProvider
    {
        public override float Order => 50.0f;
        public override ProviderType? Key => ProviderType.AFFISE_SDK_POS;
        
        private const string TYPE_SANDBOX = "Sandbox";
        private const string TYPE_PRODUCTION = "Production";

        private readonly IInitPropertiesStorage _initProperties;

        public IsProductionPropertyProvider(IInitPropertiesStorage initProperties)
        {
            _initProperties = initProperties;
        }

        public override string Provide()
        {
            return _initProperties.GetProperties().IsProduction ? TYPE_PRODUCTION : TYPE_SANDBOX;
        }
    }
}