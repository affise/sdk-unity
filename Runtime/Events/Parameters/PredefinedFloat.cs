namespace AffiseAttributionLib.Events.Parameters
{
    public enum PredefinedFloat
    {
        PREFERRED_PRICE_RANGE,
        PRICE,
        REVENUE,
        LAT,
        LONG
    }
    
    public static class PredefinedFloatExt
    {
        public static string ToValue(this PredefinedFloat param)
        {
            return $"{PredefinedConstants.PREFIX}{param.Value()}";
        }

        private static string Value(this PredefinedFloat param)
        {
            return param switch
            {
                PredefinedFloat.PREFERRED_PRICE_RANGE => "preferred_price_range",
                PredefinedFloat.PRICE => "price",
                PredefinedFloat.REVENUE => "revenue",
                PredefinedFloat.LAT => "lat",
                PredefinedFloat.LONG => "long",
                _ => null
            };
        }
    }
}