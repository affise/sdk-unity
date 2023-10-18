#nullable enable
using AffiseAttributionLib.Events.Subscription;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Custom
{
    public class UserCustomSubscriptionEvent : BaseSubscriptionEvent
    {
        private readonly string _type;
        private readonly string _subtype;
        
        public UserCustomSubscriptionEvent(string type, string subtype, JSONObject data)
            : base(data)
        {
            _type = type;
            _subtype = subtype;
        }
        
        public UserCustomSubscriptionEvent(string type, string subtype, JSONObject data, string? userData)
            : base(data, userData)
        {
            _type = type;
            _subtype = subtype;
        }

        public override string Type() => _type;

        public override string SubType() => _subtype;
    }
}