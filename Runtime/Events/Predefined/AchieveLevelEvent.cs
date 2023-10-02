namespace AffiseAttributionLib.Events.Predefined
{
    public class AchieveLevelEvent : NativeEvent
    {
        public AchieveLevelEvent() : base()
        {}
        public AchieveLevelEvent(string userData) : base(userData: userData)
        {}
        public AchieveLevelEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.ACHIEVE_LEVEL.ToEventName();
    }
}