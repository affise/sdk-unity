#nullable enable
using AffiseAttributionLib.Debugger.Network;
using AffiseAttributionLib.Debugger.Validate;

namespace AffiseAttributionLib.Debugger
{
    public interface IAffiseDebugApi
    {
        /**
         * Won't work on Production
         *
         * Validate credentials
         */
        public void Validate(DebugOnValidateCallback callback);
        
        /**
         * Won't work on Production
         *
         * Show request/response data
         */
        public void Network(DebugOnNetworkCallback callback);

        /**
         * Debug get version of flutter library
         */
        public string Version();

        /**
         * Debug get version of native library Android/iOS
         */
        public string? VersionNative();
    }
}