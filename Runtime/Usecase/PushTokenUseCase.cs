#nullable enable

using AffiseAttributionLib.Settings;
using AffiseAttributionLib.Utils;

namespace AffiseAttributionLib.Usecase
{
    internal class PushTokenUseCase : IPushTokenUseCase
    {
        private const string KEY_APP_PUSHTOKEN = "com.affise.attribution.init.PUSHTOKEN";
        private const string KEY_APP_PUSHTOKEN_SERVICE = "com.affise.attribution.init.PUSHTOKEN_SERVICE";
        
        private string? _pushToken;
        private string? _pushTokenService;
        
        public void AddPushToken(string pushToken, PushTokenService service)
        {
            PrefUtils.SaveString(KEY_APP_PUSHTOKEN, pushToken);
            PrefUtils.SaveString(KEY_APP_PUSHTOKEN_SERVICE, service.Service());
        }

        public string? GetPushToken()
        {
            return _pushToken ??= PrefUtils.GetString(KEY_APP_PUSHTOKEN, null);
        }

        public string? GetPushTokenService()
        {
            return _pushTokenService ??= PrefUtils.GetString(KEY_APP_PUSHTOKEN_SERVICE, null);
        }
    }
}