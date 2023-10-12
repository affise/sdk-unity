namespace AffiseAttributionLib.Debugger.Network
{
    internal interface IDebugNetworkUseCase
    {
        void OnRequest(DebugOnNetworkCallback onDebug);
    }
}