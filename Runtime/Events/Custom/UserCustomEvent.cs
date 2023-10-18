#nullable enable

namespace AffiseAttributionLib.Events.Custom
{
    public class UserCustomEvent : NativeEvent
    {
        private readonly string _eventName;

        public UserCustomEvent(string eventName)
            : base()
        {
            _eventName = eventName;
        }
        
        public UserCustomEvent(string eventName, string? userData)
            : base(userData)
        {
            _eventName = eventName;
        }
        
        public UserCustomEvent(string eventName, string? userData, long timeStampMillis)
            : base(userData, timeStampMillis)
        {
            _eventName = eventName;
        }

        public override string GetName() => _eventName;
    }
}