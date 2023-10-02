using AffiseAttributionLib.AffiseParameters.Base;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    /**
     * Provider for parameter [ProviderType.STORE]
     */
    internal class StoreProvider : StringPropertyProvider
    {
        public override float Order => 5.0f;
        public override ProviderType? Key => ProviderType.STORE;
        public override string Provide() {
#if UNITY_STANDALONE_WIN
            return "exe";
#else
            return null;
#endif
        }
    }
}