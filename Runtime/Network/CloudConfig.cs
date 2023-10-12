using System.Collections.Generic;

namespace AffiseAttributionLib.Network
{
    public static class CloudConfig
    {
        private static readonly IEnumerable<string> Urls = new List<string>()
        {
            "https://tracking.affattr.com/postback"
        };

        public static IEnumerable<string> GetUrls() => Urls;
        
        public static readonly Dictionary<string, string> Headers = new()
        {
            { "Content-Type", "application/json; charset=utf-8" }
        };
    }
}