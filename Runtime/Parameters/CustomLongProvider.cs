using System;
using AffiseAttributionLib.AffiseParameters.Base;

namespace AffiseAttributionLib.AffiseParameters
{
    internal class CustomLongProvider : LongPropertyProvider
    {
        public override float Order { get; }

        public override string Key { get; }
        
        private readonly Func<long?> _action;

        public CustomLongProvider(string key, float order, Func<long?> action)
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