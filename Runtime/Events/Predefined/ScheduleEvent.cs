namespace AffiseAttributionLib.Events.Predefined
{
    public class ScheduleEvent: NativeEvent
    {
        public ScheduleEvent(): base()
        {}
        public ScheduleEvent(string userData): base(userData: userData)
        {}
        public ScheduleEvent(string userData, long timeStampMillis): base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.SCHEDULE.ToValue();
    }
}