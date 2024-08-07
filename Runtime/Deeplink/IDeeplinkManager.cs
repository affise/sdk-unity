using System;

namespace AffiseAttributionLib.Deeplink
{
    internal interface IDeeplinkManager
    {
        /**
         * Needs to be called upon app init to properly initialize manager
         */
        void Init();

        /**
         * Sets [callback] to invoke when app receives deeplink
         */
        void SetDeeplinkCallback(DeeplinkCallback callback);

        /**
         * Process [uri] as deeplink, returns [Boolean] indicating if deeplink is processed successfully
         */
        void HandleDeeplink(Uri uri);
    }
}