namespace AffiseAttributionLib.Debugger.Validate
{
    public interface IDebugValidateUseCase
    {
        void Validate(DebugOnValidateCallback onComplete);
    }
}