using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Extensions;
using UnityEngine;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.LANGUAGE]
     */
    internal class LanguageProvider : StringPropertyProvider
    {
        public override float Order => 40.0f;
        public override ProviderType? Key => ProviderType.LANGUAGE;
        public override string Provide() => Application.systemLanguage.ToCode();
    }
}