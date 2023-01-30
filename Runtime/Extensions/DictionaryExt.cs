using System.Collections.Generic;
using AffiseAttributionLib.Events.Predefined;
using SimpleJSON;

namespace AffiseAttributionLib.Extensions
{
    internal static class DictionaryExt
    {
        public static JSONObject ToJson(this Dictionary<PredefinedParameters, string> predefinedParameters)
        {
            var result = new JSONObject();
            foreach (var (key, value) in predefinedParameters)
            {
                result.Add(key.ToValue(), new JSONString(value));
            }

            return result;
        }
    }
}