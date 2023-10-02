namespace AffiseAttributionLib.Events.Predefined
{
    public class AddToWishlistEvent : NativeEvent
    {
        public AddToWishlistEvent() : base()
        {}
        public AddToWishlistEvent(string userData) : base(userData: userData)
        {}
        public AddToWishlistEvent(string userData, long timeStampMillis) : base(userData, timeStampMillis)
        {}

        public override string GetName() => EventName.ADD_TO_WISHLIST.ToEventName();
    }
}