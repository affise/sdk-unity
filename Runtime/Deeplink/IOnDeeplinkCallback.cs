using System;

namespace AffiseAttributionLib.Deeplink
{
    /**
     * Interface describing callback that is going to be triggered when deeplink is received by application
     */
    public interface IOnDeeplinkCallback
    {
        /**
         * Triggered when new deeplink [uri] is received by application with
         */
        bool HandleDeeplink(Uri uri);
    }
}