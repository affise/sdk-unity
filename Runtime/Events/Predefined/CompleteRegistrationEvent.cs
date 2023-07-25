using System;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class CompleteRegistrationEvent : NativeEvent
    {
        public CompleteRegistrationEvent(): base()
        {}
        public CompleteRegistrationEvent(string userData): base(userData: userData)
        {}
        public CompleteRegistrationEvent(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        [Obsolete("use CompleteRegistrationEvent(userData, timeStampMillis)")]
        public CompleteRegistrationEvent(JSONObject registration, long timeStampMillis, string userData)
            :base(userData, timeStampMillis)
        {
            AnyData = registration;
        }

        public override string GetName() => EventName.COMPLETE_REGISTRATION.ToValue();
    }
}