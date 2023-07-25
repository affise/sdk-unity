namespace AffiseAttributionLib.Events.Parameters
{
    public enum PredefinedListObject
    {
        CONTENT_LIST
    }
    
    public static class PredefinedListObjectExt
    {
        public static string ToValue(this PredefinedListObject param)
        {
            return param switch
            {
                PredefinedListObject.CONTENT_LIST => "affise_p_content_list",
                _ => null
            };
        }
    }
}