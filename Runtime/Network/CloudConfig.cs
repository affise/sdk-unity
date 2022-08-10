using System.Collections.Generic;

namespace AffiseAttributionLib.Network
{
    public static class CloudConfig
    {
        private static IEnumerable<string> _urls = new List<string>()
        {
            "https://tracking.affattr.com/postback"
        };

        public static IEnumerable<string> GetUrls() => _urls;
    }
}