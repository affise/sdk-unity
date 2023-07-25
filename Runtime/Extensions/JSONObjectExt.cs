using System.Collections.Generic;
using SimpleJSON;

namespace AffiseAttributionLib.Extensions
{
    internal static class JSONObjectExt
    {
        public static JSONNode ToJsonNode(this object value)
        {
            var json = value switch
            {
                double doubleValue => new JSONNumber(doubleValue),
                int intValue => new JSONNumber(intValue),
                float floatValue => new JSONNumber(floatValue),
                bool boolValue => new JSONBool(boolValue),
                long longValue => new JSONNumber(longValue),
                string stringValue => new JSONString(stringValue),
                JSONNode jsonNodeValue => jsonNodeValue,
                List<JSONObject> listValue => listValue.ToJsonArray(),
                List<string> listValue => listValue.ToJsonArray(),
                Dictionary<string, object> mapValue => mapValue.ToJsonObject(),
                _ => null
            };
            return json;
        }
        
        public static JSONObject AddAny(this JSONObject json, string key, object value)
        {
            json[key] = value.ToJsonNode();
            return json;
        }
        
        public static JSONArray AddAny(this JSONArray json, object value)
        {
            json.Add(value.ToJsonNode());
            return json;
        }

        public static JSONArray ToJsonArray<T>(this List<T> list)
        {
            var result = new JSONArray();
            foreach (var item in list)
            {
                if (item is null) continue;
                result.Add(item.ToJsonNode());
            }
            return result;
        }

        public static JSONObject ToJsonObject<T>(this Dictionary<string, T> map)
        {
            var result = new JSONObject();
            foreach (var (key, value) in map)
            {
                if (key is null) continue;
                if (value is null) continue;
                result[key] = value.ToJsonNode();
            }
            return result;
        }
    }
}