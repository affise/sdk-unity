namespace AffiseAttributionLib.Native
{
    internal enum ConnectionType
    {
        WIFI,
        MOBILE
    }

    internal static class ConnectionTypeExtensions
    {
        public static string ToValue(this ConnectionType type)
        {
            return type switch
            {
                ConnectionType.WIFI => "WIFI",
                ConnectionType.MOBILE => "MOBILE",
                _ => null
            };
        }
    }
}