#nullable enable
using System.Collections.Generic;
using AffiseAttributionLib.Deeplink;
using AffiseAttributionLib.Extensions;
using AffiseAttributionLib.Modules;
using SimpleJSON;

namespace AffiseAttributionLib.Native.Utils
{
    internal static class DataMapper
    {
        private const string DEEPLINK = "deeplink";
        private const string SCHEME = "scheme";
        private const string HOST = "host";
        private const string PATH = "path";
        private const string PARAMETERS = "parameters";
        
        public static string ToNonNullString(JSONNode? json)
        {
            return json?.Value ?? "";
        }

        public static List<AffiseKeyValue> ToAffiseKeyValueList(JSONNode? json)
        {
            var result = new List<AffiseKeyValue>();
            if (json is null) return result;
            var jsonArray = json.AsArray;
            if (jsonArray is null) return result;
            foreach (var (_, jsonNode) in jsonArray)
            {
                var jsonObject = jsonNode?.AsObject;
                if (jsonObject is null) continue;
                result.Add(new AffiseKeyValue(jsonObject));
            }

            return result;
        }

        public static DeeplinkValue ToDeeplinkValue(JSONNode? from)
        {
            var json = from?.AsObject;
            var parameters = new Dictionary<string, List<string>>();
            var paramObject = json?[PARAMETERS]?.AsObject;
            if (paramObject is not null)
            {
                foreach (var (key, value) in paramObject)
                {
                    parameters[key] = value?.AsArray?.ToListOfStrings() ?? new List<string>();
                }
            }
            
            return new DeeplinkValue(
                deeplink: json?[DEEPLINK]?.Value ?? "",
                scheme: json?[SCHEME]?.Value,
                host: json?[HOST]?.Value,
                path: json?[PATH]?.Value,
                parameters: parameters
            );
        }
    }
}