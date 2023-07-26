using System;
using UnityEngine;

namespace AffiseAttributionLib.Utils
{
    internal static class PrefUtils
    {
        private const string PREFIX = "Affise";

        private static string Key(string key) => $"{PREFIX}.{key.ToLower()}";
        
        public static void CheckSaveString(string key, Func<string> func)
        {
            if (!string.IsNullOrEmpty(PlayerPrefs.GetString(key))) return;
            PlayerPrefs.SetString(Key(key), func());
        }
        
        public static void SaveBoolean(string key, bool value)
        {
            PlayerPrefs.SetInt(Key(key), value ? 1 : 0);
        }
        
        public static void SaveLong(string key, long value)
        {
            PlayerPrefs.SetString(Key(key), value.ToString());
        }
        
        public static void SaveString(string key, string value)
        {
            PlayerPrefs.SetString(Key(key), value);
        }
        
        public static long GetLong(string key, long defaultValue = 0)
        {
            var value = PlayerPrefs.GetString(Key(key), defaultValue.ToString());
            return Convert.ToInt64(value);;
        }
        
        public static bool GetBoolean(string key, bool defaultValue = false)
        {
            return PlayerPrefs.GetInt(Key(key), 1) > 0;
        }
        
        public static string GetString(string key, string defaultValue = "")
        {
            return PlayerPrefs.GetString(Key(key), defaultValue);
        }
    }
}