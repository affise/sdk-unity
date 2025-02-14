namespace AffiseAttributionLib.Usecase
{
    internal interface ISendDataToServerUseCase
    {
        void Send(bool withDelay = true, bool sendEmpty = true);
    }
}