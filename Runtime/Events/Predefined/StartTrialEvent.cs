namespace AffiseAttributionLib.Events.Predefined
{
    public class StartTrialEvent : NativeEvent
    {
        public StartTrialEvent() : base()
        {}
        public StartTrialEvent(string userData) : base(userData: userData)
        {}
        public StartTrialEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.START_TRIAL.ToValue();
    }
}