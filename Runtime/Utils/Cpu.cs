using System;
using System.Collections.Generic;
using System.Globalization;
using SystemInfo = UnityEngine.Device.SystemInfo;

namespace AffiseAttributionLib.Utils
{
    internal static class Cpu
    {
        public static string Type()
        {
            var inf = new List<string>();
            if (CultureInfo.InvariantCulture.CompareInfo.IndexOf(SystemInfo.processorType, "ARM", CompareOptions.IgnoreCase) >= 0)
            {
                inf.Add(Environment.Is64BitProcess ? "arm64" : "arm");
            }
            else
            {
                // Must be in the x86 family.
                inf.Add(Environment.Is64BitProcess ? "x86_64" : "x86");
            }

            inf.Add(SystemInfo.processorType);
            return string.Join(", ", inf);
        }
    }
}