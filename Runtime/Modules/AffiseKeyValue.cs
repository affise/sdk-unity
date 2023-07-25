using System.Collections.Generic;
using SimpleJSON;

namespace AffiseAttributionLib.Modules
{
    public class AffiseKeyValue
    {
        public string Value { get; }

        public string Key { get; }

        internal AffiseKeyValue(JSONObject json) : this(key: json["key"], value: json["value"])
        {
        }

        public AffiseKeyValue(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }

    internal static class AffiseKeyValueExt
    {
        public static List<AffiseKeyValue> ToAffiseKeyValueList(this JSONNode json)
        {
            var result = new List<AffiseKeyValue>();
            var jsonArray = json?.AsArray;
            if (jsonArray is null) return result;
            foreach (var (key, jsonNode) in jsonArray)
            {
                var jsonObject = jsonNode?.AsObject;
                if (jsonObject is null) continue;
                result.Add(new AffiseKeyValue(jsonObject));
            }

            return result;
        }
    }
}
