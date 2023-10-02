namespace AffiseAttributionLib.Events.Predefined
{
    public class UnlockAchievementEvent : NativeEvent
    {
        public UnlockAchievementEvent() : base()
        {}
        public UnlockAchievementEvent(string userData) : base(userData: userData)
        {}
        public UnlockAchievementEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.UNLOCK_ACHIEVEMENT.ToEventName();
    }
}