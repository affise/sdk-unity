using AffiseAttributionLib.AffiseParameters.Base;
using AffiseAttributionLib.Extensions;
using UnityEngine;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.LANGUAGE]
     */
    internal class LanguageProvider : StringPropertyProvider
    {
        public override float Order => 40.0f;
        public override string Key => Parameters.LANGUAGE;
        public override string Provide() => Application.systemLanguage.ToCode();
    }
}