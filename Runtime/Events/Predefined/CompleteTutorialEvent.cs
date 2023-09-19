namespace AffiseAttributionLib.Events.Predefined
{
    public class CompleteTutorialEvent : NativeEvent
    {
        public CompleteTutorialEvent() : base()
        {}
        public CompleteTutorialEvent(string userData) : base(userData: userData)
        {}
        public CompleteTutorialEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.COMPLETE_TUTORIAL.ToValue();
    }
}