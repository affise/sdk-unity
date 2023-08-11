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
            return $"{PredefinedConstants.PREFIX}{param.Value()}";
        }

        private static string Value(this PredefinedListString param)
        {
            return param switch
            {
                PredefinedListString.CONTENT_IDS => "content_ids",
                _ => null
            };
        }
    }
}