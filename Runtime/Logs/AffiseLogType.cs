using System;
using System.Collections.Generic;
using System.Linq;

namespace AffiseAttributionLib.AffiseParameters.Logs
{
    public enum AffiseLogType
    {
        NETWORK,
        DEVICEDATA,
        USERDATA,
        SDKLOG
    }

    public static class AffiseLogTypeExtensions
    {
        public static string Type(this AffiseLogType type) => type switch
        {
            AffiseLogType.NETWORK => "affise_sdklog_network",
            AffiseLogType.DEVICEDATA => "affise_sdklog_ddata",
            AffiseLogType.USERDATA => "affise_sdklog_udata",
            AffiseLogType.SDKLOG => "affise_sdklog_main",
            _ => null
        };

        public static IEnumerable<AffiseLogType> Values() =>
            Enum.GetValues(typeof(AffiseLogType)).Cast<AffiseLogType>();
    }
}