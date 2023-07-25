using AffiseAttributionLib.AffiseParameters.Base;
using UnityEngine;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.APP_VERSION_RAW]
     */
    internal class AppVersionRawProvider : StringPropertyProvider
    {
        public override float Order => 4.0f;
        public override string Key => Parameters.APP_VERSION_RAW;
        public override string Provide() => Application.version;
    }
}