using AffiseAttributionLib.AffiseParameters.Base;
using UnityEngine;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.APP_VERSION_RAW]
     */
    internal class AppVersionRawProvider : StringPropertyProvider
    {
        public override string Provide() => Application.version;
    }
}