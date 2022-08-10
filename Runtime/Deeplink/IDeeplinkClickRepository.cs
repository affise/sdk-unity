namespace AffiseAttributionLib.Deeplink
{
    internal interface IDeeplinkClickRepository
    {
        /**
         * Sets flag [isDeeplink] describing if app was opened by deeplink
         */
        void SetDeeplinkClick(bool isDeeplink);

        /**
         * Returns flag describing if app was opened by deeplink
         */
        bool IsDeeplinkClick();

        /**
         * Store deeplink that has been used to open this app
         */
        void SetDeeplink(string deeplink);

        /**
         * returns deeplink that has been used to open this app or null
         */
        string GetDeeplink();
    }
}