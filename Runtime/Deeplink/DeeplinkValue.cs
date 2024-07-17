#nullable enable

using System.Collections.Generic;
using System.Linq;

namespace AffiseAttributionLib.Deeplink
{
    public class DeeplinkValue
    {
        public readonly string Deeplink;
        
        public readonly string? Scheme;
        
        public readonly string? Host;
        
        public readonly string? Path;
        public Dictionary<string, List<string>> Parameters { get; }

        public DeeplinkValue(
            string deeplink,
            string? scheme,
            string? host,
            string? path,
            Dictionary<string, List<string>> parameters
        )
        {
            Deeplink = deeplink;
            Scheme = scheme;
            Host = host;
            Path = path;
            Parameters = parameters;
        }

        public override string ToString()
        {
            var list = Parameters.Select(h => $"{h.Key}=[{string.Join(", ", h.Value)}]").ToList();
            var parameters = string.Join(", ", list);
            return $"DeeplinkValue(scheme={Scheme}, host={Host}, path={Path}, parameters=[{parameters}])";
        }
    }
}