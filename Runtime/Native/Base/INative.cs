#nullable enable

namespace AffiseAttributionLib.Native.Base
{
    internal interface INative
    {
        delegate void AffiseNativeCallback(string eventName, string data);

        T? Native<T>(string name, string json);

        T? Native<T>(string name);

        void Native(string name, string json);
        
        void Native(string name);

        void SetCallback(AffiseNativeCallback method) 
        { }

        void NativeHandleDeeplink(string url)
        { }
    }
}