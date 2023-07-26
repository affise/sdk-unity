namespace AffiseAttributionLib.Events.Parameters
{
    public enum PredefinedObject
    {
        CONTENT
    }
    
    public static class PredefinedObjectExt
    {
        public static string ToValue(this PredefinedObject param)
        {
            return param switch
            {
                PredefinedObject.CONTENT => "affise_p_content",
                _ => null
            };
        }
    }
}