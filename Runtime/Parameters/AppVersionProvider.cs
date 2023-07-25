using AffiseAttributionLib.AffiseParameters.Base;
using UnityEngine;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.APP_VERSION]
     */
    internal class AppVersionProvider : StringPropertyProvider
    {
        public override float Order => 3.0f;
        public override string Key => Parameters.APP_VERSION;
        public override string Provide() => Application.version;
    }
}