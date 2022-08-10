using AffiseAttributionLib.AffiseParameters.Base;
using UnityEngine;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.APP_VERSION]
     */
    internal class AppVersionProvider : StringPropertyProvider
    {
        public override string Provide() => Application.version;
    }
}