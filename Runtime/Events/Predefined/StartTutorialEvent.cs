namespace AffiseAttributionLib.Events.Predefined
{
    public class StartTutorialEvent : NativeEvent
    {
        public StartTutorialEvent() : base()
        {}
        public StartTutorialEvent(string userData) : base(userData: userData)
        {}
        public StartTutorialEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.START_TUTORIAL.ToEventName();
    }
}