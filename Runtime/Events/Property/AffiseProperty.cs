namespace AffiseAttributionLib.Events.Property
{
    public enum AffiseProperty
    {
        TIMESTAMP
    }

    internal static class AffisePropertyExtensions
    {
        public static string ToValue(this AffiseProperty key)
        {
            return key switch
            {
                AffiseProperty.TIMESTAMP => "timestamp",
                _ => null
            };
        }
    }
}