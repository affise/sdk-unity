using System.Text.RegularExpressions;
using UnityEngine;

namespace AffiseAttributionLib.Utils
{
    internal static class OSUtils
    {
        public static string GetOSVersion()
        {
#if UNITY_STANDALONE_WIN
            return GetWindowsVersion();
#else
            return "";
#endif
        }

        private static string GetWindowsVersion()
        {
            var osName = SystemInfo.operatingSystem;
            var rx = new Regex(@"Windows\s+(\d+|\w+)\s+\(", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var matches = rx.Matches(osName);
            if (matches.Count <= 0) return "";
            
            return matches[0].Groups[1].Value;
        }
    }
}