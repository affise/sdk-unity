#nullable enable
using AffiseAttributionLib.Settings;

namespace AffiseAttributionLib.Usecase
{
    public interface IPushTokenUseCase
    {

        void AddPushToken(string pushToken, PushTokenService service);
        string? GetPushToken();
        string? GetPushTokenService();
    }
}