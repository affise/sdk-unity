using SimpleJSON;

namespace AffiseAttributionLib.Events.Predefined
{
    public class OpenedFromPushNotificationEvent : NativeEvent
    {
        private readonly string _details;
        private readonly string _userData;

        public OpenedFromPushNotificationEvent(string details, string userData)
        {
            _details = details;
            _userData = userData;
        }

        public override JSONNode Serialize() => new JSONObject
        {
            ["affise_event_opened_from_push_notification"] = _details
        };

        public override string GetName() => "OpenedFromPushNotification";

        public override string GetUserData() => _userData;
    }
}