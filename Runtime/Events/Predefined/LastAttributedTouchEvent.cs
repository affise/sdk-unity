namespace AffiseAttributionLib.Events.Predefined
{
    public class LastAttributedTouchEvent : NativeEvent
    {
        public LastAttributedTouchEvent() : base()
        {}
        public LastAttributedTouchEvent(string userData) : base(userData: userData)
        {}
        public LastAttributedTouchEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.LAST_ATTRIBUTED_TOUCH.ToValue();
    }
}