using System;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class StartRegistrationEvent : NativeEvent
    {
        public StartRegistrationEvent(): base()
        {}
        public StartRegistrationEvent(string userData): base(userData: userData)
        {}
        public StartRegistrationEvent(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        [Obsolete("use StartRegistrationEvent(userData, timeStampMillis)")]
        public StartRegistrationEvent(JSONObject registration, long timeStampMillis, string userData)
            :base(userData, timeStampMillis)
        {
            AnyData = registration;
        }

        public override string GetName() => EventName.START_REGISTRATION.ToValue();
    }
}