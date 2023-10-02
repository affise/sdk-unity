namespace AffiseAttributionLib.Events.Predefined
{
    public class CustomId06Event : NativeEvent
    {
        public CustomId06Event() : base()
        {}
        public CustomId06Event(string userData) : base(userData: userData)
        {}
        public CustomId06Event(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.CUSTOM_ID_06.ToEventName();
    }
}