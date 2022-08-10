using AffiseAttributionLib.AffiseParameters.Base;
using UnityEngine;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.AFFISE_PKG_APP_NAME]
     */
    internal class AffisePackageAppNameProvider : StringPropertyProvider
    {
        public override string Provide() => Application.identifier;
    }
}