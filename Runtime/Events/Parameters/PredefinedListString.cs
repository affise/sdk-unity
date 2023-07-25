namespace AffiseAttributionLib.Events.Parameters
{
    public enum PredefinedListString
    {
        CONTENT_IDS
    }
    
    public static class PredefinedListStringExt
    {
        public static string ToValue(this PredefinedListString param)
        {
            return param switch
            {
                PredefinedListString.CONTENT_IDS => "affise_p_content_ids",
                _ => null
            };
        }
    }
}