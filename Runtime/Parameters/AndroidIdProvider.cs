using AffiseAttributionLib.AffiseParameters.Base;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.ANDROID_ID]
     */
    internal class AndroidIdProvider : StringPropertyProvider
    {
        public override float Order => 30.0f;
        public override string Key => Parameters.ANDROID_ID;
        
        public override string Provide() => null;
    }
}