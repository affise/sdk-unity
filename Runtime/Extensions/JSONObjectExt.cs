﻿using System.Collections.Generic;
using System.Globalization;
using SimpleJSON;

namespace AffiseAttributionLib.Extensions
{
    internal static class JSONObjectExt
    {
        public static JSONNode ToJsonNode(this object value)
        {
            var json = value switch
            {
                string stringValue => new JSONString(stringValue),
                long longValue => new JSONNumber(longValue.ToString()),
                int intValue => new JSONNumber(intValue.ToString()),
                float floatValue => new JSONNumber(floatValue.ToString(CultureInfo.InvariantCulture)),
                double doubleValue => new JSONNumber(doubleValue.ToString(CultureInfo.InvariantCulture)),
                bool boolValue => new JSONBool(boolValue),
                JSONNode jsonNodeValue => jsonNodeValue,
                Dictionary<string, object> mapValue => mapValue.ToJsonObject(),
                List<JSONObject> listValue => listValue.ToJsonArray(),
                List<Dictionary<string, object>> listValue => listValue.ToJsonArray(),
                List<string> listValue => listValue.ToJsonArray(),
                List<long> listValue => listValue.ToJsonArray(),
                List<int> listValue => listValue.ToJsonArray(),
                List<float> listValue => listValue.ToJsonArray(),
                List<double> listValue => listValue.ToJsonArray(),
                List<bool> listValue => listValue.ToJsonArray(),
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