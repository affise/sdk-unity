using UnityEngine;

namespace AffiseAttributionLib.Extensions
{
    internal static class ApplicationExt
    {
        public static string ToValue(this RuntimePlatform platform)
        {
            return platform switch
            {
                RuntimePlatform.OSXEditor => Platform.OSX,
                RuntimePlatform.OSXPlayer => Platform.OSX,
                RuntimePlatform.OSXServer => Platform.OSX,

                RuntimePlatform.WindowsPlayer => Platform.Windows,
                RuntimePlatform.WindowsEditor => Platform.Windows,
                RuntimePlatform.WindowsServer => Platform.Windows,

                RuntimePlatform.LinuxPlayer => Platform.Linux,
                RuntimePlatform.LinuxEditor => Platform.Linux,
                RuntimePlatform.LinuxServer => Platform.Linux,

                RuntimePlatform.IPhonePlayer => Platform.IOS,
                RuntimePlatform.Android => Platform.Android,
                
                RuntimePlatform.XboxOne => Platform.Xbox,
                RuntimePlatform.GameCoreXboxOne => Platform.Xbox,
                RuntimePlatform.GameCoreXboxSeries => Platform.Xbox,
                
                RuntimePlatform.PS4 => Platform.PS,
                RuntimePlatform.PS5 => Platform.PS,

                _ => Platform.Other
            };
        }
    }
}