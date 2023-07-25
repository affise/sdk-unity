using UnityEngine;

namespace AffiseAttributionLib.Extensions
{
    internal static class SystemInfoExt
    {
        public static string ToCustom(this DeviceType deviceType)
        {
            return deviceType switch
            {
                DeviceType.Unknown => Platform.Unknown,
                DeviceType.Handheld => Platform.Smartphone,
                DeviceType.Console => Platform.Console,
                DeviceType.Desktop => Platform.Desktop,
                _ => null
            };
        }

        public static string ToCustom(this OperatingSystemFamily os)
        {
            return os switch
            {
                OperatingSystemFamily.Other => Platform.Other,
                OperatingSystemFamily.MacOSX => Platform.OSX,
                OperatingSystemFamily.Windows => Platform.Windows,
                OperatingSystemFamily.Linux => Platform.Linux,
                _ => null
            };
        }
    }
}