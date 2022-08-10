using UnityEngine;

namespace AffiseAttributionLib.Extensions
{
    internal static class SystemInfoExt
    {
        public static string ToCustom(this DeviceType deviceType)
        {
            return deviceType switch
            {
                DeviceType.Unknown => Names.k_Unknown,
                DeviceType.Handheld => Names.k_Smartphone,
                DeviceType.Console => Names.k_Console,
                DeviceType.Desktop => Names.k_Desktop,
                _ => null
            };
        }

        public static string ToCustom(this OperatingSystemFamily os)
        {
            return os switch
            {
                OperatingSystemFamily.Other => Names.k_Other,
                OperatingSystemFamily.MacOSX => Names.k_OSX,
                OperatingSystemFamily.Windows => Names.k_Windows,
                OperatingSystemFamily.Linux => Names.k_Linux,
                _ => null
            };
        }
    }
}