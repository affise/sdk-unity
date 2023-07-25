namespace AffiseAttributionLib.Modules
{
    public enum AffiseModules
    {
        Advertising,
        Network,
        Phone,
        Status,
    }
    
    internal static class AffiseModulesExt
    {
        public static string ToValue(this AffiseModules key)
        {
            return key switch
            {
                AffiseModules.Advertising => "Advertising",
                AffiseModules.Network => "Network",
                AffiseModules.Phone => "Phone",
                AffiseModules.Status => "Status",
                _ => null
            };
        }
    }
}