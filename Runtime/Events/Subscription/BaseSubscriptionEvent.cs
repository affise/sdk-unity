using SimpleJSON;

namespace AffiseAttributionLib.Events.Subscription
{
    public abstract class BaseSubscriptionEvent : NativeEvent
    {
        private readonly JSONObject _data;
        private readonly string _userData;

        protected BaseSubscriptionEvent(JSONObject data, string userData)
        {
            _data = data;
            _userData = userData;
        }

        public override JSONNode Serialize()
        {
            var result = new JSONObject
            {
                [SubscriptionParameters.AFFISE_SUBSCRIPTION_EVENT_TYPE_KEY] = SubType(),
            };
            
            foreach (var (key, value) in _data)
            {
                result.Add(key, value);
            }

            return result;
        }

        public override string GetName() => Type();

        public override string GetUserData() => _userData;

        public abstract string Type();

        public abstract string SubType();
    }
}