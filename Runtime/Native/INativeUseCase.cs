namespace AffiseAttributionLib.Native
{
    internal interface INativeUseCase
    {
        long? GetInstalledTime() => null;
        
        long? GetInstalledBeginTime() => null;
        
        string GetApiVersion() => null;
        
        string GetOSVersion() => null;
        
        string GetIsp() => null;

        string GetAndroidId() => null;

        string GetDeviceManufacturer() => null;
        
        string GetConnectionType() => null;
        
        string GetNetworkType() => null;
        
        string GetStore() => null;
        
        string GetGaidAdid() => null;
        
        string GetReferrer() => null;
    }
}