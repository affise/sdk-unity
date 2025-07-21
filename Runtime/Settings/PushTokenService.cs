#nullable enable

namespace AffiseAttributionLib.Settings
{
    public enum PushTokenService
    {
        FIREBASE,
        APPLE
    }
    
    public static class PushTokenServiceExt
    {
        public static string? Service(this PushTokenService service)
        {
            return service switch
            {
                PushTokenService.FIREBASE => "fms",
                PushTokenService.APPLE => "apns",
                _ => null
            };
        }
    }
}