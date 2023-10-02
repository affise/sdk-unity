using System;
using AffiseAttributionLib.AffiseParameters.Base;

namespace AffiseAttributionLib.AffiseParameters.Providers
{
    internal class CustomLongProvider : LongPropertyProvider
    {
        public override float Order { get; }

        public override ProviderType? Key { get; }
        
        private readonly Func<long?> _action;

        public CustomLongProvider(ProviderType key, float order, Func<long?> action)
        {
            Key = key;
            Order = order;
            _action = action;
        }
        
        public override long? Provide()
        {
            return _action?.Invoke();
        }
    }
}