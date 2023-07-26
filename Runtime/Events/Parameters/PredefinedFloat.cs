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
            return param switch
            {
                PredefinedFloat.PREFERRED_PRICE_RANGE => "affise_p_preferred_price_range",
                PredefinedFloat.PRICE => "affise_p_price",
                PredefinedFloat.REVENUE => "affise_p_revenue",
                PredefinedFloat.LAT => "affise_p_lat",
                PredefinedFloat.LONG => "affise_p_long",
                _ => null
            };
        }
    }
}