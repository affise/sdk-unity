using AffiseAttributionLib.Modules;

namespace AffiseAttributionLib.Module.Status.UseCase
{
    public interface ICheckStatusUseCase
    {
        void Send(OnKeyValueCallback onComplete);
    }
}