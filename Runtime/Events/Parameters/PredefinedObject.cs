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
            return $"{PredefinedConstants.PREFIX}{param.Value()}";
        }

        private static string Value(this PredefinedObject param)
        {
            return param switch
            {
                PredefinedObject.CONTENT => "content",
                _ => null
            };
        }
    }
}