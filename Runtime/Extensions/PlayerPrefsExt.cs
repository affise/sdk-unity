using UnityEngine;

namespace AffiseAttributionLib.Extensions
{
    internal static class PlayerPrefsExt
    {
        
        public static void SetLong( string key, long value)
        {
            PlayerPrefs.SetString(key, $"{value}");
        }

        public static long GetLong( string key, long defaultValue)
        {
            long.TryParse(PlayerPrefs.GetString(key, $"{defaultValue}"), out var result);
            return result;
        }

        public static long GetLong(string key) => GetLong(key, 0L);
    }
}