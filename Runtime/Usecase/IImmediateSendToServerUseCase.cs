using AffiseAttributionLib.Events;

namespace AffiseAttributionLib.Usecase
{
    public interface IImmediateSendToServerUseCase
    {
        void SendNow(AffiseEvent affiseEvent, OnSendSuccessCallback success, OnSendFailedCallback failed);
    }
}