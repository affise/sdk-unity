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
        public override string Provide() => Application.systemLanguage.ToCode();
    }
}