namespace AffiseAttributionLib.Events.Predefined
{
    public class OpenedFromPushNotificationEvent : NativeEvent
    {
        public OpenedFromPushNotificationEvent() : base()
        {}
        public OpenedFromPushNotificationEvent(string userData) : base(userData: userData)
        {}
        public OpenedFromPushNotificationEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.OPENED_FROM_PUSH_NOTIFICATION.ToValue();
    }
}