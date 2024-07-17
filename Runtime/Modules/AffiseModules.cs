#nullable enable
using System;

namespace AffiseAttributionLib.Modules
{
    public enum AffiseModules
    {
        Advertising,
        AndroidId,
        Link,
        Network,
        Phone,
        Status,
    }
    
    internal static class AffiseModulesExt
    {
        public static string Module(this AffiseModules key)
        {
            return key switch
            {
                AffiseModules.Advertising => "Advertising",
                AffiseModules.AndroidId => "AndroidId",
                AffiseModules.Link => "Link",
                AffiseModules.Network => "Network",
                AffiseModules.Phone => "Phone",
                AffiseModules.Status => "Status",
                _ => ""
            };
        }
        public static AffiseModules? From(string? value)
        {
            if (value is null) return null;
            foreach (var type in Enum.GetValues(typeof(AffiseModules)))
            {
                if (type is not AffiseModules modules) continue;
                if (modules.Module() == value) return modules;
            }
            return null;
        }
    }
}