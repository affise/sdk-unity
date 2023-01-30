using System;

namespace AffiseAttributionLib.Deeplink
{
    /**
     * Delegate triggered when new deeplink [uri] is received by application with
     */
    public delegate bool DeeplinkCallback(Uri uri);
}