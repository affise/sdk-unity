using System;
using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class InviteEvent : NativeEvent
    {
        public InviteEvent(): base()
        {}
        public InviteEvent(string userData): base(userData: userData)
        {}
        public InviteEvent(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        [Obsolete("use InviteEvent(userData, timeStampMillis)")]
        public InviteEvent(JSONObject invite, long timeStampMillis, string userData)
            :base(userData, timeStampMillis)
        {
            AnyData = invite;
        }

        public override string GetName() => EventName.INVITE.ToValue();
    }
}