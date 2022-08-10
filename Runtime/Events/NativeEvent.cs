namespace AffiseAttributionLib.Events
{
    public abstract class NativeEvent: AffiseEvent
    {
        public override string GetCategory() => "native";
    }
}