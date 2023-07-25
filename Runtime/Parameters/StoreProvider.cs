using AffiseAttributionLib.AffiseParameters.Base;

namespace AffiseAttributionLib.AffiseParameters
{
    /**
     * Provider for parameter [Parameters.STORE]
     */
    internal class StoreProvider : StringPropertyProvider
    {
        public override float Order => 5.0f;
        public override string Key => Parameters.STORE;
        public override string Provide() {
#if UNITY_STANDALONE_WIN
            return "exe";
#else
            return null;
#endif
        }
    }
}