using System;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class LoginEvent : NativeEvent
    {
        public LoginEvent(): base()
        {}
        public LoginEvent(string userData): base(userData: userData)
        {}
        public LoginEvent(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        [Obsolete("use LoginEvent(userData, timeStampMillis)")]
        public LoginEvent(JSONObject login, long timeStampMillis, string userData)
            :base(userData, timeStampMillis)
        {
            AnyData = login;
        }

        public override string GetName() => EventName.LOGIN.ToValue();
    }
}