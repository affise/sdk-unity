namespace AffiseAttributionLib.Events.Predefined
{
    public class ContactEvent: NativeEvent
    {
        public ContactEvent(): base()
        {}
        public ContactEvent(string userData): base(userData: userData)
        {}
        public ContactEvent(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.CONTACT.ToValue();
    }
}