using System;

namespace AffiseAttributionLib.Events.Predefined
{
    public class DeepLinkedEvent : NativeEvent
    {
        public DeepLinkedEvent(): base()
        {}
        public DeepLinkedEvent(string userData): base(userData: userData)
        {}
        public DeepLinkedEvent(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        [Obsolete("use DeepLinkedEvent(userData, timeStampMillis)")]
        public DeepLinkedEvent(bool isLinked, string userData): base(userData: userData)
        {
            AnyData = isLinked;
        }

        public override string GetName() => EventName.DEEP_LINKED.ToValue();
    }
}