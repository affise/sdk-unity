namespace AffiseAttributionLib.Native
{
    internal interface INative
    {
        delegate void NativeEventCallback(string eventName, string data);

        T Native<T>(string name, string json);

        T Native<T>(string name);

        void Native(string name, string json);
        
        void Native(string name);

        void EventCallback(NativeEventCallback method) {
        }
    }
}