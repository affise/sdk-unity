using AffiseAttributionLib.AffiseParameters.Base;

namespace AffiseAttributionLib.AffiseParameters
{
    public class EmptyStringProvider : StringPropertyProvider
    {
        public override float Order { get; }

        public override string Key { get; }

        public EmptyStringProvider(string key, float order)
        {
            Key = key;
            Order = order;
        }

        public override string Provide() => "";
    }
}