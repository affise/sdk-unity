using UnityEngine;

namespace AffiseAttributionLib.Extensions
{
    internal static class ApplicationExt
    {
        public static string ToOS(this RuntimePlatform platform)
        {
            return platform switch
            {
                RuntimePlatform.OSXEditor => Names.k_OSX,
                RuntimePlatform.OSXPlayer => Names.k_OSX,
                RuntimePlatform.OSXServer => Names.k_OSX,

                RuntimePlatform.WindowsPlayer => Names.k_Windows,
                RuntimePlatform.WindowsEditor => Names.k_Windows,
                RuntimePlatform.WindowsServer => Names.k_Windows,

                RuntimePlatform.LinuxPlayer => Names.k_Linux,
                RuntimePlatform.LinuxEditor => Names.k_Linux,
                RuntimePlatform.LinuxServer => Names.k_Linux,

                RuntimePlatform.IPhonePlayer => Names.k_IOS,
                RuntimePlatform.Android => Names.k_Android,

                _ => Names.k_Other
            };
        }
    }
}