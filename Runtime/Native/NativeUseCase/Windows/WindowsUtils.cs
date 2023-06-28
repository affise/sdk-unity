using System.Text.RegularExpressions;
using UnityEngine;

namespace AffiseAttributionLib.Native.NativeUseCase.Windows
{
    internal static class WindowsUtils
    {
        public static string GetOSVersion()
        {
            var osName = SystemInfo.operatingSystem;
            var rx = new Regex(@"Windows\s+(\d+|\w+)\s+\(", RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var matches = rx.Matches(osName);
            if (matches.Count > 0)
            {
                return matches[0].Groups[1].Value;
            }

            return "";
        }
    }
}