using AffiseAttributionLib.AffiseParameters.Base;
using UnityEngine;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.AFFISE_PKG_APP_NAME]
     */
    internal class AffisePackageAppNameProvider : StringPropertyProvider
    {
        public override float Order => 2.0f;
        public override string Key => Parameters.AFFISE_PKG_APP_NAME;
        public override string Provide() => Application.identifier;
    }
}