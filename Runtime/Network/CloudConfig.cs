#nullable enable
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AffiseAttributionLib.Network
{
    public static class CloudConfig
    {
        private const string DefaultDomain = "https://tracking.affattr.com/";
        private const string Path = "postback";
        
        private static string _domain = DefaultDomain;
        
        private static IEnumerable<string> _urls = new List<string>()
        {
            $"{_domain}{Path}"
        };

        public static IEnumerable<string> GetUrls() => _urls;
        
        public static readonly Dictionary<string, string> Headers = new()
        {
            { "Content-Type", "application/json; charset=utf-8" }
        };

        internal static void SetupDomain(string? domain)
        {
            if (string.IsNullOrWhiteSpace(domain)) return;

            _domain = domain.EndsWith("/") ? domain : $"{domain}/";
            _domain = Regex.Replace(_domain  , "/+", "/").Replace(":/", "://");

            _urls = new[]
            {
                GetUrl(Path)
            };
        }

        public static string GetUrl(string path)
        {
            try
            {
                var server = new Uri(_domain);
                if (Uri.TryCreate(server, path, out var uriResult))
                {
                    return uriResult.ToString();
                }
            }
            catch (Exception)
            {
                // ignored
            }

            return $"{DefaultDomain}{Path}";
        }
    }
}