using AffiseAttributionLib.AffiseParameters.Base;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    public class EmptyStringProvider : StringPropertyProvider
    {
        public override float Order { get; }

        public override ProviderType? Key { get; }

        public EmptyStringProvider(ProviderType key, float order)
        {
            Key = key;
            Order = order;
        }

        public override string Provide() => "";
    }
}