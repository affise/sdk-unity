using System;

namespace AffiseAttributionLib.Logs
{
    /**
     * Manager logs interface
     */
    internal interface ILogsManager
    {
        /**
         * Add [throwable] of network
         */
        void AddNetworkError(Exception exception);

        /**
         * Add [throwable] of device
         */
        void AddDeviceError(Exception exception);

        /**
         * Add [throwable] of user
         */
        void AddUserError(Exception exception);

        /**
         * Add [throwable] of sdk
         */
        void AddSdkError(Exception exception);

        /**
         * Add [message] error of device
         */
        void AddDeviceError(string message);
    }
}