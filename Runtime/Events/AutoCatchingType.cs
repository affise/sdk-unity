namespace AffiseAttributionLib.Events
{
    public enum AutoCatchingType
    {
        BUTTON,
        TEXT,

        IMAGE_BUTTON,
        IMAGE,

        GROUP
    }
    
    public static class AutoCatchingTypeExtensions
    {
        public static string ToValue(this AutoCatchingType type)
        {
            return type switch
            {
                AutoCatchingType.BUTTON => "BUTTON",
                AutoCatchingType.TEXT => "TEXT",
                
                AutoCatchingType.IMAGE_BUTTON => "IMAGE_BUTTON",
                AutoCatchingType.IMAGE => "IMAGE",
                
                AutoCatchingType.GROUP => "GROUP",
                _ => null
            };
        }
    }
}