namespace AffiseAttributionLib.Events.Predefined
{
    public class CompleteTrialEvent : NativeEvent
    {
        public CompleteTrialEvent() : base()
        {}
        public CompleteTrialEvent(string userData) : base(userData: userData)
        {}
        public CompleteTrialEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.COMPLETE_TRIAL.ToEventName();
    }
}