using AffiseAttributionLib.AffiseParameters.Base;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.AFFISE_SDK_VERSION]
     */
    internal class AffSDKVersionProvider : StringPropertyProvider
    {
        public override float Order => 47.0f;
        public override string Key => Parameters.AFFISE_SDK_VERSION;
        public override string Provide() => "1.6.1";
    }
}